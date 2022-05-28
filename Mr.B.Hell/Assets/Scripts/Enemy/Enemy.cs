using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isDead { get; private set; }
    public Player player { get; private set; }

    Material mat;
    Rigidbody2D rb;

    float scale = 30f;
    float fade = 1f;
    float minScale = 10f, maxScale = 70f;

    [SerializeField] int lifePoints = 3;

    // Start is called before the first frame update

    private void Awake()
    {
        player = FindObjectOfType<Player>();

    }

    public virtual void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isDead)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDead = false;
                Destroy(gameObject, 0.1f);
            }

            mat.SetFloat("_Fade", fade);
        }
    }

    public void MinusLife(int amount)
    {
        lifePoints -= amount;
        if (lifePoints <= 0)
        {
            Dead();
        }

        print("hihiih");
    }

    private void Dead()
    {
        print(rb);
        rb.velocity = Vector2.zero;

        isDead = true;

        scale = Mathf.Round(Random.Range(minScale, maxScale));
        mat.SetFloat("_Scale", scale);

        GetComponent<Collider2D>().enabled = false;

        //set glow inactive
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
