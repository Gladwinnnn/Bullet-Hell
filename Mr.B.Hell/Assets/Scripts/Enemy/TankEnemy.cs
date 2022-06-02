using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TankEnemy : Enemy
{
    [Header("Rotation")]
    [SerializeField] bool rotate = true;
    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] bool clockwise = true;
    float count = 1;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rotateSpeed *= clockwise ? 1 : -1;
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
        CRotate();
    }

    void CRotate()
    {
        if(rotate)
        {
            transform.localRotation = Quaternion.Euler(0, 0, count);
            count -= rotateSpeed;
        }
    }

}
