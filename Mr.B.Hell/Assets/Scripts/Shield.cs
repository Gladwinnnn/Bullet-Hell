using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform center;
    public float degreesPerSecond = -90.0f;
    private Vector3 v;

    [Header("Rotation")]
    [SerializeField] bool rotate = true;
    [SerializeField] float rotateSpeed = 1f;
    float count = 1;

    void Start() 
    {
        v = transform.position - center.position;
    }
        
    void Update () 
    {
        v = Quaternion.AngleAxis (degreesPerSecond * Time.deltaTime, Vector3.forward) * v;
        transform.position = center.position + v;

        if(rotate)
        {
            transform.localRotation = Quaternion.Euler(0, 0, count);
            count -= rotateSpeed;
        }
    }
}
