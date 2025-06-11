using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    Transform this_transform;
    public bool x;
    public bool y;
    public bool z;
    public float speed;

    void Start() 
    {
        this_transform = transform; 
    }

    void Update()
    {
        if (x) 
        {
            this_transform.Rotate(1 * Time.deltaTime * speed, 0, 0);
        }
        if (y)
        {
            this_transform.Rotate(0, 1 * Time.deltaTime * speed, 0);
        }
        if (z)
        {
            this_transform.Rotate(0,0, 1 * Time.deltaTime * speed);
        }
    }

}
