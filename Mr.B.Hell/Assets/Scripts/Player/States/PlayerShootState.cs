using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerAbilityState
{

    public PlayerShootState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.Shoot(playerData.bulletPrefab, playerData.shootForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!secondaryAttackInput)
        {
            stateMachine.ChangeState(player.MoveState);
        }

        if (secondaryAttackInput && Time.time >= startTime + playerData.shootCoolDown)
        {
            startTime = Time.time;
            player.Shoot(playerData.bulletPrefab, playerData.shootForce);
        }

        if (player.CanGrenade && specialAttackInput && player.GrenadeState.canFire())
        {
            stateMachine.ChangeState(player.GrenadeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.Movement.Move(xInput, yInput, playerData.moveForceRestriction);
    }

    public bool canFire() => Time.time >= startTime + playerData.shootCoolDown;

}
