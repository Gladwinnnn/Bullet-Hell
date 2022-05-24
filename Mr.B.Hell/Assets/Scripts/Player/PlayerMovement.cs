using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{

    private PlayerData playerData;
    private Rigidbody2D RB;

    public PlayerMovement(PlayerData data, Rigidbody2D RB)
    {
        this.playerData = data;
        this.RB = RB;
    }

    public void Move(float xInput, float yInput, float moveForce)
    {
        Vector2 movement = new Vector2(xInput, yInput);

        RB.MovePosition(RB.position + movement * moveForce * Time.fixedDeltaTime);
    }

    public void Look(Vector2 mosPos)
    {
        Vector2 lookDir = mosPos - RB.position;
        float angle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg + 90f;
        RB.rotation = angle;
    }
}
