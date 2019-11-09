using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGravityChangerBehaviour : MonoBehaviour
{
    private float gravityMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        gravityMagnitude = 9.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            Physics.gravity = new Vector3(0,gravityMagnitude, 0);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            Physics.gravity = new Vector3(0,-gravityMagnitude, 0);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            Physics.gravity = new Vector3(-gravityMagnitude, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            Physics.gravity = new Vector3(gravityMagnitude,0, 0);
        }
    }
}
