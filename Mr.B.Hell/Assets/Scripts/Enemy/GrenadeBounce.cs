using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBounce : MonoBehaviour
{
    Vector3 lastVelocity;
    Rigidbody2D rb;
    int id;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!flag)
        {
            id = collision.gameObject.GetInstanceID();
            flag = true;
        } 
        if (collision.gameObject.tag == "AOE Shooter" && id == collision.gameObject.GetInstanceID())
        {
            return;
        }

        var speed = lastVelocity.magnitude;
        var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = dir * speed;
    }
}
