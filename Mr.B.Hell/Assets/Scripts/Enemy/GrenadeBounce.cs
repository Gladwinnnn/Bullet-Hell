using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBounce : MonoBehaviour
{
    Vector3 lastVelocity;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = dir * speed;
    }
}