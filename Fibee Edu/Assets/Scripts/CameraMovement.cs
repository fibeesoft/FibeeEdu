using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 3.5f;
    private float X;
    private float Y;
    //Vector3 camZoom;
    private void Start()
    {
        //camZoom.z = -25f;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
        /*
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
        */
        
        //camZoom.z += Input.mouseScrollDelta.y * 12f ;
        //transform.localPosition = new Vector3(transform.position.x, transform.position.y, camZoom.z);

    }
}

