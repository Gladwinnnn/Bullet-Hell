using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int lifePoints = 5;
    [SerializeField] int dashDamage = 1;

    [Header("Dash Effect")]
    [SerializeField] float dashForce = 7.5f;
    bool dashState = true;

    [Header("Echo Effect")]
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float startTimeBetweenSpawn;
    [SerializeField] GameObject echo;

    [Header("Shake Effect")]
    [SerializeField] float shake = 0.05f;
    Vector2 orginalTransform;

    Player player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        orginalTransform = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (Mathf.Abs(distanceFromPlayer) <= 5f && dashState)
        {
            StartCoroutine(PerformAttack());
        }
        else if (distanceFromPlayer > 5f && !dashState)
        {
            StopCoroutine(PerformAttack());
            dashState = true;
        }

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

    void Dash()
    {
        Vector2 distance = player.transform.position - transform.position;
        distance.Normalize();
        rb.AddForce(distance * dashForce, ForceMode2D.Impulse);

        if (timeBetweenSpawns <= 0)
        {
            GameObject obj = Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(obj, 0.5f);
            timeBetweenSpawns = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }

        dashState = false;
    }

    void Shaking()
    {
        float posX = Random.Range(-shake, shake);
        float poxY = Random.Range(-shake, shake);
        Vector2 shakePos = new Vector2(posX, poxY);
        transform.localPosition = (Vector2)orginalTransform - shakePos;
    }

    IEnumerator PerformAttack()
    {
        moveSpeed = 0;
        Shaking();
        yield return new WaitForSeconds(2f);
        Dash();
        moveSpeed = 1f;
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
