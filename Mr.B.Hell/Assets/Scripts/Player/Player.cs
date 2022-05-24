using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region State Variables
    
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
  
    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Variables
    
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
    }

    // Start is called before the first frame update
    void Start()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();

        Movement = new PlayerMovement(playerData, RB); 

        StateMachine.Initialize(MoveState);

    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }


}
