using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] GameObject particlesPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy)
        {
            enemy.MinusLife(damage);
        }

        Vector2 distance = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y);
        if (!particlesPrefab)
        {
            return;
        }

        var particle = Instantiate(particlesPrefab, transform.position, Quaternion.identity);
        particle.transform.up = distance;

        Destroy(particle, 2f);

        Destroy(gameObject);
    }
}
