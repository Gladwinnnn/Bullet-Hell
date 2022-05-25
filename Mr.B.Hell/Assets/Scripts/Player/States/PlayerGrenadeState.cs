using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrenadeState : PlayerAbilityState
{
    private float cooldown;


    public PlayerGrenadeState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        cooldown = playerData.grenadeCoolDown;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool canFire() => Time.time >= startTime + cooldown;
}
