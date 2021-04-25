using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOnTriggerDestroy : MonoBehaviour
{
    public GameObject orig;

    public Enemy1 c_Enemy;

    private void Awake()
    {

    }

    private void Start()
    {
        c_Enemy = GameObject.Find("Enemy1").GetComponent<Enemy1>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            Destroy(orig);
            c_Enemy.isSerch = false;
            c_Enemy.timeElapsed = 0;
        }
    
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(orig);
            c_Enemy.isSerch = false;
            c_Enemy.timeElapsed = 0;
    
    
        }
    }
}
