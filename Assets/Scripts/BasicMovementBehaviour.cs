using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class BasicMovementBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up);
        }

        
        
    }
}
