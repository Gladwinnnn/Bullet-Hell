using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int dashDamage = 1;

    Player player;

    float countDownToDash = 1.5f, dashDuration = 0.25f, speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
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
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Mathf.Abs(distance) <= 3.5f)
        {
            moveSpeed = 0f;
            if (countDownToDash <= 0)
            {
                moveSpeed = 10f;

                if (dashDuration <= 0)
                {
                    countDownToDash = 1.5f;
                    dashDuration = 0.25f;
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
        else
        {
            moveSpeed = 1f;
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
