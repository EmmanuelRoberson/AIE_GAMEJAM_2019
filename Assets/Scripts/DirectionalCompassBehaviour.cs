using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalCompassBehaviour : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = (Math.Abs(rotateSpeed) < 1) ? 4 : rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //forward rotate
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
           transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        //backwards rotate
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(-Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        //rotate left
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); 
        }

        // rotate right
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(-Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
