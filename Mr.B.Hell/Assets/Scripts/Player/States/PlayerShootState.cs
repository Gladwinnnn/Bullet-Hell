using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerAbilityState
{
    float lastShootTime;
    int shootingLock;
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
        shootingLock = 1;
    }

    public override void Exit()
    {
        base.Exit();
        player.Abilities.OnCooldown(2, playerData.shootCoolDown);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Debug.Log(shootingLock);
        if(!secondaryAttackInput && shootingLock >= 3)
        {
            stateMachine.ChangeState(player.MoveState);
        }

        if (Time.time >= lastShootTime + playerData.timeBetweenShot)
        {
            lastShootTime = Time.time;
            player.Shoot(playerData.bulletPrefab, playerData.shootForce);
            ShakeCam();
            shootingLock++;
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
