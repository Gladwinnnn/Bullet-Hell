using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int shootDamage = 1;

    [Header("Projectile")]
    [SerializeField] GameObject enemyBullet;
    [SerializeField] float projectileSpeed = 10f;
    float countDownToFire = 1.5f, speed = 1f;

    [Header("Fire Point")]
    [SerializeField] private Transform firePoint;

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
        Fire();

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
    
        Vector2 distance = player.transform.position - transform.position;
        transform.up = distance;
    }

    void Fire()
    {
        if (countDownToFire <= 0)
        {
            GameObject bullet = Instantiate(enemyBullet, firePoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * projectileSpeed;
            countDownToFire = 1.5f;
        }
        else
        {
            countDownToFire -= Time.deltaTime * speed;
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
