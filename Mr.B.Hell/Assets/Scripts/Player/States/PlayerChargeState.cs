using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeState : PlayerAbilityState
{
    Vector2 orginalTransform;
    int multiplyer;
    float lastChargedTime;

    public PlayerChargeState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        orginalTransform = player.transform.GetChild(0).localPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        lastChargedTime = startTime;
        multiplyer = 0;
    }

    public override void Exit()
    {
        base.Exit();
        player.transform.GetChild(0).localPosition = orginalTransform;
        lastChargedTime = Time.time;
        Debug.Log(multiplyer);
        player.Damage = multiplyer;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Shaking();

        if(!primaryAttackInput || Time.time >= startTime + playerData.maxChargeTime)
        {
            stateMachine.ChangeState(player.DashState);
        }

        if(Time.time >= lastChargedTime + playerData.chargeTime) 
        {
            multiplyer++;
            lastChargedTime = Time.time;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void Shaking()
    {
        float posX = Random.Range(-playerData.shake, playerData.shake);
        float poxY = Random.Range(-playerData.shake, playerData.shake);
        Vector2 shakePos = new Vector2(posX, poxY);
        //Debug.Log(orginalTransform);
        player.transform.GetChild(0).localPosition = (Vector2)orginalTransform - shakePos;
    }

    public bool canFire() => Time.time >= lastChargedTime + playerData.chargeCoolDown;

    public float GetMultiplyer() => multiplyer;

}
