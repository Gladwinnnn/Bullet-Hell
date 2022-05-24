using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int dashDamage = 1;

    [SerializeField] GameObject player;

    float countDownToDash = 1f, dashDuration = 0.5f, speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SuddenDash();

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

    void SuddenDash()
    {
        if (countDownToDash <= 0)
        {
            moveSpeed = 5f;

            if (dashDuration <= 0)
            {
                moveSpeed = 1f;
                countDownToDash = 2f;
                dashDuration = 0.5f;
            }
            else
            {
                dashDuration -= Time.deltaTime * speed;
            }
        }
        else
        {
            countDownToDash -= Time.deltaTime * speed;
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
