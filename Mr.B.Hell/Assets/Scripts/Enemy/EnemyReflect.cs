using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyReflect : MonoBehaviour
{
    [SerializeField] float knockBackForce = 100f;
    [SerializeField] Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) return;

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        Vector2 difference = collision.transform.position - transform.position;
        difference = difference.normalized * knockBackForce;
        rb.AddForce(difference, ForceMode2D.Impulse);
        collision.transform.up = difference;

        if(collision.gameObject.layer == 7) // player bullet
        {
            collision.gameObject.layer = 8;
            Destroy(collision.gameObject.GetComponent<PlayerDamage>());
            collision.GetComponent<Destroy>().enabled = true;
            collision.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
            collision.gameObject.transform.GetChild(1).GetComponent<Light2D>().color = color;
            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);

        }
    }
}
