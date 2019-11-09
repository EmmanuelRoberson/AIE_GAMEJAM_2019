using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLineBehaviour : MonoBehaviour
{
    public Transform originPoint;

    public Transform destinationPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originPoint.position;
        transform.LookAt(destinationPoint);
    }
}
