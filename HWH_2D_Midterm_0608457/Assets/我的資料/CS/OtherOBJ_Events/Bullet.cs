using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player mPlayer;
    public float BulletSpeed;
    private void Update()
    {
        
        gameObject.transform.Translate(BulletSpeed*Time.deltaTime,0,0);
    }

    private void OnEnable()
    {
        Destroy(gameObject,1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {       
            Debug.Log("Enter");
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Stay");
            Destroy(gameObject);
        }
    }
}
