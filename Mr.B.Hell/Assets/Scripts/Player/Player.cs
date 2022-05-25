using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region State Variables
    
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerShootState ShootState { get; private set; }
    public PlayerGrenadeState GrenadeState { get; private set; }


    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Variables

    [SerializeField]
    private Transform firePoint;

    public bool CanShoot { get; private set; }
    public bool CanGrenade { get; private set; }

    #endregion

    #region Components

    public PlayerInputHandler InputHandler { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public PlayerMovement Movement { get; private set; }

    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        ShootState = new PlayerShootState(this, StateMachine, playerData, "shoot");
        GrenadeState = new PlayerGrenadeState(this, StateMachine, playerData, "grenade");

    }

    // Start is called before the first frame update
    void Start()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();

        Movement = new PlayerMovement(playerData, RB, transform); 

        StateMachine.Initialize(MoveState);

        CanShoot = true;
        CanGrenade = true;
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
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

}
