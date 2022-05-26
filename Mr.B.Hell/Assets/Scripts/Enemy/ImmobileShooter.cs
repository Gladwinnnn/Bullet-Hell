using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobileShooter : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int lifePoints = 5;
    [SerializeField] int shootDamage = 1;

    [Header("Projectile")]
    [SerializeField] GameObject enemyFire;
    [SerializeField] float projectileSpeed = 10f;
    float countDownToFire = 1.5f, speed = 1f;

    [Header("Rotation")]
    [SerializeField] bool rotate = true;
    [SerializeField] float rotateSpeed = 1f;
    float count = 1;

    [Header("Fire Points")]
    [SerializeField] private Transform firePointUp;
    [SerializeField] private Transform firePointDown;
    [SerializeField] private Transform firePointLeft;
    [SerializeField] private Transform firePointRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Rotate();

        if (lifePoints == 0)
        {
            Die();
        }
    }

    void Fire()
    {
        if (countDownToFire <= 0)
        {
            // upwards trajectory
            GameObject fireUp = Instantiate(enemyFire, firePointUp.transform.position, Quaternion.identity);
            fireUp.GetComponent<Rigidbody2D>().velocity = (new Vector2(0,1)).normalized * projectileSpeed;

            // downwards trajectory
            GameObject fireDown = Instantiate(enemyFire, firePointDown.transform.position, Quaternion.identity);
            fireDown.GetComponent<Rigidbody2D>().velocity = (new Vector2(0,-1)).normalized * projectileSpeed;

            // right trajectory
            GameObject fireRight = Instantiate(enemyFire, firePointRight.transform.position, Quaternion.identity);
            fireRight.GetComponent<Rigidbody2D>().velocity = (new Vector2(1,0)).normalized * projectileSpeed;

            // left trajectory
            GameObject fireLeft = Instantiate(enemyFire, firePointLeft.transform.position, Quaternion.identity);
            fireLeft.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1,0)).normalized * projectileSpeed;

            countDownToFire = 1.5f;
        }
        else
        {
            countDownToFire -= Time.deltaTime * speed;
        }
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
