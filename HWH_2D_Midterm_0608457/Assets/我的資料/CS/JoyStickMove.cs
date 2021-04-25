using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    protected Joystick joystick;
    [Range(1, 200)] public float Speed;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }


    void Update()
    {
       var c_rigibody = gameObject.GetComponent<Rigidbody2D>();
       c_rigibody.velocity = new Vector2(joystick.Horizontal * Speed, c_rigibody.velocity.y);
    }
}
