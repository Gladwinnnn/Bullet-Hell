using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEShooterEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int dashDamage = 1;

    [Header("Projectile")]
    [SerializeField] GameObject enemyGrenade;
    // [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float throwForce = 0.5f;
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
        // Move();
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
    }

    void Fire()
    {
        if (countDownToFire <= 0)
        {
            GameObject grenade = Instantiate(enemyGrenade, firePoint.transform.position, Quaternion.identity);
            Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
            Vector2 distance = player.transform.position - transform.position;

            rb.AddForce(distance * throwForce, ForceMode2D.Impulse);
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
