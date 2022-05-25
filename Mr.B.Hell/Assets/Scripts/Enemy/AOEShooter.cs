using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEShooter : MonoBehaviour
{
[Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int shootDamage = 1;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    float countDownToFire = 1.5f, speed = 1f;

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void Fire()
    {
        if (countDownToFire <= 0)
        {
            // upwards trajectory
            GameObject laserUp = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserUp.GetComponent<Rigidbody2D>().velocity = (new Vector2(0,1)).normalized * projectileSpeed;
            GameObject laserUpRight = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserUpRight.GetComponent<Rigidbody2D>().velocity = (new Vector2(1,1)).normalized * projectileSpeed;
            GameObject laserUpLeft = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserUpLeft.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1,1)).normalized * projectileSpeed;

            // downwards trajectory
            GameObject laserDown = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserDown.GetComponent<Rigidbody2D>().velocity = (new Vector2(0,-1)).normalized * projectileSpeed;
            GameObject laserDownRight = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserDownRight.GetComponent<Rigidbody2D>().velocity = (new Vector2(1,-1)).normalized * projectileSpeed;
            GameObject laserDownLeft = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserDownLeft.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1,-1)).normalized * projectileSpeed;

            // right trajectory
            GameObject laserRight = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserRight.GetComponent<Rigidbody2D>().velocity = (new Vector2(1,0)).normalized * projectileSpeed;

            // left trajectory
            GameObject laserLeft = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserLeft.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1,0)).normalized * projectileSpeed;

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
