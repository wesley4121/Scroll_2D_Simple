using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, startpos;
    public GameObject cam;
    [Range(-5f,5f)]   public float parallaxEFX;

    private void Awake()
    {
        cam = GameObject.Find("Main Camera");
    }

    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

 

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEFX);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
