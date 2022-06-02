using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isDead { get; private set; }
    public Player player { get; private set; }

    Material mat;
    public Rigidbody2D rb { get; private set; }

    float scale = 30f;
    float fade = 1f;
    float minScale = 10f, maxScale = 70f;

    [SerializeField] int lifePoints = 3;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int scoreValue;

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
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }

        //print("hihiih");
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

    public void Move()
    {
        rb.velocity = Vector2.zero;
        if (!player) return;
        var targetPosition = player.transform.position;
        var movementThisFrame = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
    }

    public void Rotate()
    {
        if (!player) return;
        Vector2 distance = player.transform.position - transform.position;
        transform.up = distance;
    }
}
