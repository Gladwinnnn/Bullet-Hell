using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobileShooter : Enemy
{

    [Header("Projectile")]
    [SerializeField] GameObject enemyBullet;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float countDown = 1f;
    float countDownToFire = 1f, speed = 1f;

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
    public override void Start()
    {
        base.Start();
        countDownToFire = countDown;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isDead) return;   
        Fire();
        CRotate();
    }

    void Fire()
    {
        if (countDownToFire <= 0)
        {
            // upwards trajectory
            GameObject fireUp = Instantiate(enemyBullet, firePointUp.transform.position, Quaternion.identity);
            //fireUp.GetComponent<Rigidbody2D>().velocity = (new Vector2(0,1)).normalized * projectileSpeed;            
            fireUp.GetComponent<Rigidbody2D>().AddForce(firePointUp.up * projectileSpeed, ForceMode2D.Impulse);

            // downwards trajectory
            GameObject fireDown = Instantiate(enemyBullet, firePointDown.transform.position, Quaternion.identity);
            //fireDown.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, -1)).normalized * projectileSpeed;
            fireDown.GetComponent<Rigidbody2D>().AddForce(-firePointDown.up * projectileSpeed, ForceMode2D.Impulse);

            // right trajectory
            GameObject fireRight = Instantiate(enemyBullet, firePointRight.transform.position, Quaternion.identity);
            //fireRight.GetComponent<Rigidbody2D>().velocity = (new Vector2(1, 0)).normalized * projectileSpeed;
            fireRight.GetComponent<Rigidbody2D>().AddForce(firePointRight.right * projectileSpeed, ForceMode2D.Impulse);

            // left trajectory
            GameObject fireLeft = Instantiate(enemyBullet, firePointLeft.transform.position, Quaternion.identity);
            //fireLeft.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1, 0)).normalized * projectileSpeed;
            fireLeft.GetComponent<Rigidbody2D>().AddForce(-firePointLeft.right * projectileSpeed, ForceMode2D.Impulse);

            countDownToFire = countDown;
        }
        else
        {
            countDownToFire -= Time.deltaTime * speed;
        }
    }

    void CRotate()
    {
        if (rotate)
        {
            transform.localRotation = Quaternion.Euler(0, 0, count);
            count -= rotateSpeed;
        }
    }

}
