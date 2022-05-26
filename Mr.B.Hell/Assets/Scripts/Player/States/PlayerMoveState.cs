using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{

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

        if(primaryAttackInput && player.ChargeState.canFire())
        {
            stateMachine.ChangeState(player.ChargeState);
        }
        else if (player.CanShoot && secondaryAttackInput && player.ShootState.canFire())
        {
            stateMachine.ChangeState(player.ShootState);
        }
        else if (player.CanGrenade && specialAttackInput && player.GrenadeState.canFire())
        {
            stateMachine.ChangeState(player.GrenadeState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.Movement.Move(xInput, yInput, playerData.moveForce);
    }
}
