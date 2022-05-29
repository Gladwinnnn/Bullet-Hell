using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    float scrollSpeed = 0.3f;
    float currentSize;
    float direction = -0.1f;

    private Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
        currentSize = myCamera.orthographicSize;
        currentSize = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCamera.orthographicSize != currentSize)
            myCamera.orthographicSize -= direction * scrollSpeed;
    }

    public void SetCamSize(int size, float speed, float dir)
    {
        currentSize = size;
        scrollSpeed = speed;
        direction = dir;
    }
}
