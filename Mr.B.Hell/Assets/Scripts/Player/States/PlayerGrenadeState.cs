using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrenadeState : PlayerAbilityState
{
    private float cooldown;

    public PlayerGrenadeState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
        player.Shoot(playerData.grenadePrefab, playerData.grenadeForce);
        player.Abilities.OnCooldown(3, playerData.grenadeCoolDown);
        stateMachine.ChangeState(player.MoveState);
        cooldown = playerData.grenadeCoolDown;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.Movement.Move(xInput, yInput, playerData.moveForce);
    }

    public bool canFire() => Time.time >= startTime + cooldown;
}
