using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    float minScale = 10f;
    float maxScale = 70f;
    float scale = 30f;
    float fade = 1f;
    Material mat;

    public PlayerDeathState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        mat = player.transform.GetChild(0).GetComponent<SpriteRenderer>().material;
        Dead();
        player.Level.PlayerIsDead();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        //base.LogicUpdate();

        fade -= Time.deltaTime;

        if (fade <= 0f)
        {
            fade = 0f;
            //Destroy(gameObject, 0.5f);
        }

        mat.SetFloat("_Fade", fade);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void Dead()
    {
        player.RB.velocity = Vector2.zero;

        scale = Mathf.Round(Random.Range(minScale, maxScale));
        mat.SetFloat("_Scale", scale);

        player.GetComponent<CircleCollider2D>().enabled = false;

        //set glow inactive
        player.transform.GetChild(1).gameObject.SetActive(false);
    }
}
