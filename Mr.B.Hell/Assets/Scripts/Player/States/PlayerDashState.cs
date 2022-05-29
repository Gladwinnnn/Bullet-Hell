using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    float lastEchoTime; 
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.Movement.Dash(player.GetFirePoint(), playerData.dashForce);
        lastEchoTime = startTime;
    }

    public override void Exit()
    {
        base.Exit();
        player.Movement.Zero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + playerData.dashTime)
        {
            stateMachine.ChangeState(player.MoveState);
        }

        if(Time.time >= lastEchoTime + playerData.echoTime)
        {
            player.SpawnAndDestroy(playerData.echo, player.transform, player.transform.rotation);
            lastEchoTime = Time.time;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
