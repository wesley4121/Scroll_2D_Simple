using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerKey : MonoBehaviour
{
    public GameObject Lock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {       
        print("OKK");
        if (other.gameObject.CompareTag("Key"))
        {         
            print("OK");
            Destroy(Lock);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
