using System;
using UnityEngine;

public class ParticleLineBehaviour : MonoBehaviour
{
    public Transform originPoint;

    public Transform destinationPoint;

    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = originPoint.position;
        transform.LookAt(destinationPoint);

        var main = ps.main;
        main.startSpeed = Math.Abs(Vector3.Distance(this.transform.position, destinationPoint.position))/ps.main.duration;
    }
}
