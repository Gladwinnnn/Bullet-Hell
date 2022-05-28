using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    [Header("Enemy Stats")]
    [SerializeField] float moveSpeed = 0.25f;
    [SerializeField] int meleeDamage = 1;

    [Header("Rotation")]
    [SerializeField] bool rotate = true;
    [SerializeField] float rotateSpeed = 1f;
    float count = 1;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isDead)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            return;
        }
        Move();
        Rotate();
    }

    void Move()
    {
        var targetPosition = player.transform.position;
        var movementThisFrame = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
    }

    void Rotate()
    {
        if(rotate)
        {
            transform.localRotation = Quaternion.Euler(0, 0, count);
            count -= rotateSpeed;
        }
    }

}
