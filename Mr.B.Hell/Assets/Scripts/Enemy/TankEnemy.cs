using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 0.25f;
    [SerializeField] int lifePoints = 20;
    [SerializeField] int meleeDamage = 1;

    [Header("Rotation")]
    [SerializeField] bool rotate = true;
    [SerializeField] float rotateSpeed = 1f;
    float count = 1;

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
        Rotate();

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

    void Rotate()
    {
        if(rotate)
        {
            transform.localRotation = Quaternion.Euler(0, 0, count);
            count -= rotateSpeed;
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
