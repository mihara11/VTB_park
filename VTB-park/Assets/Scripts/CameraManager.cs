using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    int index = 0;

    public int start_time;

    public GameObject [] cameras;
    public int [] time_show;
    public Vector3[] start_cameras_position;
    public Vector3[] start_cameras_rotation;

    void Start()
    {
        GetStartPosition();
        Invoke("ChangeCamera", start_time);
    }
    void ChangeCamera() 
    {
        if (index > cameras.Length - 1)
        {
            RestartShow();
        }
        cameras[index].SetActive(true);
        Invoke("ChangeCamera", time_show[index]);
        index++;
    }
    void RestartShow() 
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        index  = 0;
        ReturnToStartPosition();
    }
    void GetStartPosition() 
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            start_cameras_position[i] = cameras[i].transform.position;
            start_cameras_rotation[i] = cameras[i].transform.eulerAngles;
        }
    }
    void ReturnToStartPosition()
    {
        for (int i = 0; i < cameras.Length; i++) 
        {
            cameras[i].transform.position = start_cameras_position[i];
            cameras[i].transform.rotation = Quaternion.Euler(start_cameras_position[i]);

        }
    }
}
