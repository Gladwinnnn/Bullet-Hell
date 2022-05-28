using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int shootDamage = 1;

    [Header("Projectile")]
    [SerializeField] GameObject enemyBullet;
    [SerializeField] float projectileSpeed = 10f;
    float countDownToFire = 1.5f, speed = 1f;

    [Header("Fire Point")]
    [SerializeField] private Transform firePoint;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isDead) return;
        Move();
        Fire();
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
}
