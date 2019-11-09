using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TupleClass
{
    public TupleClass(ParticleSystem particleSystem, GameObject dest)
    {
        ps = particleSystem;
        destination = dest;
    }
    
    public ParticleSystem ps;
    public GameObject destination;
}
