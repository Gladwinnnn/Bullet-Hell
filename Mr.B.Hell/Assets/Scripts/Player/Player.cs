using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region State Variables

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerChargeState ChargeState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerShootState ShootState { get; private set; }
    public PlayerGrenadeState GrenadeState { get; private set; }
    public PlayerDeathState DeathState { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Variables

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject hitParticle;

    public bool IsHit { get; private set; }
    public bool IsImmune { get; private set; }
    public bool CanShoot { get; private set; }
    public bool CanGrenade { get; private set; }
    public int Damage { get; set; } // for dash attack only - for now 

    private float lastImmuneTime;
    private float lastHitTime;

    #endregion

    #region Components

    public PlayerInputHandler InputHandler { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerHealth Health { get; private set; }

    public CameraShake CameraShake { get; private set; }

    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        MoveState = new PlayerMoveState(this, StateMachine, playerData, "idle");
        ChargeState = new PlayerChargeState(this, StateMachine, playerData, "charge");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
        ShootState = new PlayerShootState(this, StateMachine, playerData, "idle");
        GrenadeState = new PlayerGrenadeState(this, StateMachine, playerData, "idle");
        DeathState = new PlayerDeathState(this, StateMachine, playerData, "idle");

    }

    // Start is called before the first frame update
    void Start()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();

        Movement = new PlayerMovement(this, playerData, RB, transform);
        Health = new PlayerHealth(playerData);
        CameraShake = FindObjectOfType<CameraShake>();

        StateMachine.Initialize(MoveState);

        CanShoot = true;
        CanGrenade = true;

        lastHitTime = playerData.knockbackTime;
        lastImmuneTime = playerData.immunityTime;
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        Timer();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }


    public void Shoot(GameObject projectile, float force)
    {
        GameObject temp = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }

    public Transform GetFirePoint() => firePoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsImmune) return;

        if (StateMachine.CurrentState == DashState)
        {
            Dash(collision);
            return;
        }
        IsHit = true;
        IsImmune = true;

        bool flag = Health.MinusHeath(1);

        var particle = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(particle, 2f);

        if (flag)
        {
            //call level script
            StateMachine.ChangeState(DeathState);
            return;
        }

        Vector2 difference = collision.transform.position - transform.position;
        difference = difference.normalized * playerData.knockbackForce;
        //difference = difference * playerData.knockbackForce;
        RB.AddForce(-difference, ForceMode2D.Impulse);
        if (collision.gameObject.layer == 8)
            Destroy(collision.gameObject);
    }

    private void Dash(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.MinusLife(Damage);

            //Vector2 difference = collision.transform.position - transform.position;
            //difference = difference.normalized * playerData.knockbackForce;
            //collision.GetComponent<Rigidbody2D>().AddForce(-difference, ForceMode2D.Impulse);
        }
    }

    private void Timer()
    {
        if (IsImmune)
        {
            lastImmuneTime -= Time.deltaTime;

            if (lastImmuneTime < 0)
            {
                IsImmune = false;
                lastImmuneTime = playerData.immunityTime;
            }
        }

        if (IsHit)
        {
            lastHitTime -= Time.deltaTime;
            if (lastHitTime < 0)
            {
                IsHit = false;
                lastHitTime = playerData.knockbackTime;
                RB.velocity = Vector2.zero;
            }
        }
    }

    //fml what is this function
    public void SpawnAndDestroy(GameObject obj, Transform locatiom, Quaternion rotation)
    {
        GameObject temp = Instantiate(obj, locatiom.position, rotation);
        Destroy(temp, 2f);
    }

}
