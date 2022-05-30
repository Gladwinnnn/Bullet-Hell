using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerAbilityState
{
    float lastShootTime;
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
        lastShootTime = startTime;
        ShakeCam();
    }

    public override void Exit()
    {
        base.Exit();
        player.Abilities.OnCooldown(2, playerData.shootCoolDown);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!secondaryAttackInput)
        {
            stateMachine.ChangeState(player.MoveState);
        }

        if (secondaryAttackInput && Time.time >= lastShootTime + playerData.timeBetweenShot)
        {
            lastShootTime = Time.time;
            player.Shoot(playerData.bulletPrefab, playerData.shootForce);
            ShakeCam();
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

    public bool canFire() => Time.time >= lastShootTime + playerData.shootCoolDown;

    private void ShakeCam()
    {
        player.CameraShake.ShakeCamera(playerData.shakeAmount, 0.1f);
    }
}
