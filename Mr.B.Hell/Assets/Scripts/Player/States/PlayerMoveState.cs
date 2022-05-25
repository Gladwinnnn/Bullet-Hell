using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private int xInput;
    private int yInput;
    private Vector2 mousePos;
    private bool secondaryAttackInput;

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        mousePos = player.InputHandler.RawMouseInput;
        secondaryAttackInput = player.InputHandler.SecondaryAttackInput;

        player.Movement.Look(mousePos);

        if (player.CanShoot && secondaryAttackInput && player.ShootState.isReady())
        {
            stateMachine.ChangeState(player.ShootState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.Movement.Move(xInput, yInput, playerData.moveForce);
    }
}
