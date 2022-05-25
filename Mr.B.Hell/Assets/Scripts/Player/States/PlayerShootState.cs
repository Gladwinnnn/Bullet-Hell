using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerAbilityState
{
    private bool secondaryAttackInput;
    


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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        secondaryAttackInput = player.InputHandler.SecondaryAttackInput;

        if(!secondaryAttackInput)
        {
            stateMachine.ChangeState(player.MoveState);
        }

        if (secondaryAttackInput && Time.time >= startTime + playerData.shootCoolDown)
        {
            startTime = Time.time;
            player.Shoot(playerData.bulletPrefab, playerData.shootForce);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.Movement.Move(xInput, yInput, playerData.moveForceRestriction);
    }
}
