using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int dashDamage = 1;

    [SerializeField] float dashForce = 15f;
    Player player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dash();

        if (lifePoints == 0)
        {
            Die();
        }
    }

    void Move()
    {
        var targetPosition = player.transform.position;
        var movementThisFrame = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
    }

    void Dash()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (Mathf.Abs(distanceFromPlayer) <= 5f)
        {
            //delete all the print pls i lazy :)
            print(distanceFromPlayer);
            Vector2 distance = player.transform.position - transform.position;
            print(distance);
            distance.Normalize();
            print(distance);

            rb.AddForce(distance * dashForce, ForceMode2D.Impulse);
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
