using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 0.25f;
    [SerializeField] int lifePoints = 20;
    [SerializeField] int meleeDamage = 1;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

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

    void Die() 
    {
        Destroy(gameObject);
    }
}
