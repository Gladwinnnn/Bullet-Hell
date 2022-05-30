using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    moving,
    inRange,
    charging,
    attack,
}
public class AOEShooterEnemy2 : Enemy
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform firepoint;
    [SerializeField] float radius = 5f;
    [SerializeField] float charge = 1f;
    [SerializeField] float projectileSpeed = 5f;

    EnemyState enemyState;

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

        Rotate();
        switch (enemyState)
        {
            case EnemyState.moving:
                Move();
                PlayerDistance();
                break;
            case EnemyState.inRange:
                StartCoroutine(PerformAttack());
                break;
            case EnemyState.charging:
                break;
            case EnemyState.attack:
                Attack();
                break;
        }
        rb.velocity = Vector2.zero;
    }
    private void PlayerDistance()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= radius)
        {
            enemyState = EnemyState.inRange;
        }
    }

    private IEnumerator PerformAttack()
    {
        enemyState = EnemyState.charging;
        yield return new WaitForSeconds(charge);
        enemyState = EnemyState.attack;
    }

    private void Attack()
    {
        enemyState = EnemyState.moving;
        GameObject fireUp = Instantiate(projectile, firepoint.position, firepoint.rotation);
        fireUp.GetComponent<Rigidbody2D>().AddForce(firepoint.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
