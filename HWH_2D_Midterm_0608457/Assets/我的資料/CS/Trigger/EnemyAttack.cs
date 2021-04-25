using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  public GameObject mPlayer;
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      mPlayer = other.gameObject;
    }
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      mPlayer = other.gameObject;
    }
  }
}
