using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIcon : MonoBehaviour
{
    public GameObject Icon;
    public bool IconON;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IconON = true;
        Icon.transform.localScale = new Vector3(1, 1, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        IconON = true;
        Icon.transform.localScale = new Vector3(1, 1, 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IconON = false;
        Icon.transform.localScale = new Vector3(0, 0, 0);
    }
    
}
