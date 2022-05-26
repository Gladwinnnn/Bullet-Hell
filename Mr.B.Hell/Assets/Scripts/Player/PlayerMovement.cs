using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{

    private PlayerData playerData;
    private Rigidbody2D RB;
    private Transform playerTransform;

    public PlayerMovement(PlayerData data, Rigidbody2D RB, Transform transform)
    {
        this.playerData = data;
        this.RB = RB;
        this.playerTransform = transform;
    }

    public void Move(float xInput, float yInput, float moveForce)
    {
        Vector2 movement = new Vector2(xInput, yInput);

        RB.MovePosition(RB.position + movement * moveForce * Time.fixedDeltaTime);
    }

    public void Look(Vector2 mosPos)
    {
        playerTransform.up = mosPos;

        //Vector2 lookDir = mosPos;
        //float angle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg - 90f;
        //RB.rotation = angle;
    }

    public void Dash(Transform direction, float force)
    {
        RB.AddForce(direction.up * force, ForceMode2D.Impulse);
    }

    public void Zero()
    {
        RB.velocity = Vector2.zero;
    }
}
