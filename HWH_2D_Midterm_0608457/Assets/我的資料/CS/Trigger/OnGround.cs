using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class OnGround : MonoBehaviour
{
    public bool _OnGround;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Ground") || other.CompareTag("Enemy"))
        {
            _OnGround = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Enemy"))
        {
            _OnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Enemy"))
        {
            _OnGround = false;
        }
    }
}
