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

    public bool IsHit { get; private set; }
    public bool IsImmune { get; private set; }
    public bool CanShoot { get; private set; }
    public bool CanGrenade { get; private set; }

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

        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        ChargeState = new PlayerChargeState(this, StateMachine, playerData, "charge");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
        ShootState = new PlayerShootState(this, StateMachine, playerData, "shoot");
        GrenadeState = new PlayerGrenadeState(this, StateMachine, playerData, "grenade");
        DeathState = new PlayerDeathState(this, StateMachine, playerData, "death");

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
        if (StateMachine.CurrentState == DashState || IsImmune) return;

        IsHit = true;
        IsImmune = true;

        bool flag = Health.MinusHeath(1);
        if (flag)
        {
            //call level script
            StateMachine.ChangeState(DeathState);
        }

        Vector2 difference = collision.transform.position - transform.position;
        difference = difference.normalized * playerData.knockbackForce;
        //difference = difference * playerData.knockbackForce;
        RB.AddForce(-difference, ForceMode2D.Impulse);
        if (collision.gameObject.layer == 8)
            Destroy(collision.gameObject);
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



}
