using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = System.Random;

public class DestroyOnPlayerEnter : MonoBehaviour
{

    public Light dl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Random r = new Random();
        dl.intensity += 0.1f;



        var tt = other.gameObject.GetComponent<BasicMovementBehaviour>();
        tt.resetTrans = this.transform.position;
        Destroy(gameObject);

    }

}
