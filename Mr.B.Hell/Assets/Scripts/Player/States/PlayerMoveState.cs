using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{

    private bool secondaryAttackInput;
    private bool specialAttackInput;


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

        secondaryAttackInput = player.InputHandler.SecondaryAttackInput;
        specialAttackInput = player.InputHandler.SpecialAttackInput;

        if (player.CanShoot && secondaryAttackInput && player.ShootState.canFire())
        {
            stateMachine.ChangeState(player.ShootState);
        }
        else if (player.CanGrenade && specialAttackInput && player.GrenadeState.canFire())
        {
            stateMachine.ChangeState(player.GrenadeState);
        }

        Debug.Log(player.GrenadeState.canFire());
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.Movement.Move(xInput, yInput, playerData.moveForce);
    }
}
