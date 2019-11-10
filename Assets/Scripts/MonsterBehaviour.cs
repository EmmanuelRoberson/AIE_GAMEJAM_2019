using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBehaviour : MonoBehaviour
{
    public List<Sprite> spriteCranberry;

    public Image image;
    
    private float timer = 0;

    private int w = 0;

    public GameObject victim;
    
    float MoveSpeed = 4;
    float MaxDist = 10;
    float MinDist = 5;
    
    // Start is called before the first frame update
    private void Start()
    {
        w = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(victim.transform);
        transform.position += Time.deltaTime*MoveSpeed*transform.forward;
        
        timer += Time.deltaTime;
        if (timer >= 0.02)
        {
            MoveSpeed += 0.01f;
            w++;
            if (w >= spriteCranberry.Count)
            {
                w = 0;
            }

            image.sprite = spriteCranberry[w];
        }
    }
    
}
