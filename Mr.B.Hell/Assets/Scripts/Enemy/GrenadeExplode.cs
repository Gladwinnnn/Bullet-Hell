using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrenadeExplode : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sRenderer;
    Rigidbody2D rb;

    [SerializeField] float countdown;
    [SerializeField] float explodeTime;
    [SerializeField] float grenadeCountTime;
    [SerializeField] Color[] color;
    [SerializeField] int layerToChange; 

    float currentTime;
    bool flag = true;
    bool colorFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        Invoke("Explode", countdown);
        Invoke("Done", countdown + explodeTime);
        currentTime = grenadeCountTime;
        //sRenderer.material.SetColor("_Color", Color.green);
        //sRenderer.color = color[Convert.ToInt32(colorFlag)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag) return;
        if (grenadeCountTime <= 0)
        {
            //print(color[Convert.ToInt32(colorFlag)]);
            sRenderer.color = color[Convert.ToInt32(colorFlag)];
            colorFlag = !colorFlag;
            //sRenderer.enabled = !sRenderer.enabled;
            if(currentTime > 0.1)
            currentTime = currentTime / 1.2f;
            //if (currentTime <= 0.05) flag = false;
            grenadeCountTime = currentTime;
        }
        else
        {
            grenadeCountTime -= Time.deltaTime;
        }
    }

    void Explode()
    {
        sRenderer.color = color[0];
        anim.SetTrigger("explode");
        gameObject.layer = layerToChange; // point to grenade explode
        if (rb) rb.velocity = Vector2.zero;
    }

    void Done()
    {
        anim.SetTrigger("done");
        Destroy(gameObject, 1f);
    }
}
