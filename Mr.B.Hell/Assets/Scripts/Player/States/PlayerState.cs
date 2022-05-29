using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    private string animBoolName;

    protected float startTime;

    protected int xInput;
    protected int yInput;
    protected bool secondaryAttackInput;
    protected bool specialAttackInput;
    protected bool primaryAttackInput;
    private Vector2 mousePos;
    

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        //player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        //player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        //Clamp here
        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        primaryAttackInput = player.InputHandler.PrimaryAttackInput;
        secondaryAttackInput = player.InputHandler.SecondaryAttackInput;
        specialAttackInput = player.InputHandler.SpecialAttackInput;

        mousePos = player.InputHandler.EditedMouseInput;

        player.Movement.Look(mousePos - (Vector2) player.transform.position);
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }
}
