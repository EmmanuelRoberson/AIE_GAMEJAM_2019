using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ParticleLineBehaviour : MonoBehaviour
{
    public Transform originPoint;

    private ParticleSystem ps;
    public Transform destinationPoint;
    
    // Start is called before the first frame update
    void Start()
    {

        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (destinationPoint == null)
        {
            Destroy(ps.gameObject);
        }
        
        transform.position = originPoint.position;
        transform.LookAt(destinationPoint);

        var main = ps.main;
        main.startSpeed = Math.Abs(Vector3.Distance(this.transform.position, destinationPoint.position))/ps.main.duration;
    }

    public void Hide()
    {
        gameObject.active = false;
    }

    public void Show()
    {
        gameObject.active = true;
    }
    
}
