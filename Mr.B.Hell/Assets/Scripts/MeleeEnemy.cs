using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int meleeDamage = 1;

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            lifePoints -= 1;
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}