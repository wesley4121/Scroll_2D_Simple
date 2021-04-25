using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeeRange : MonoBehaviour
{
 public bool isFound;
 public bool isWall;
 public Transform mTargePos;
 private void OnTriggerEnter2D(Collider2D other)
 {
  if (other.CompareTag("EnemyWall"))
  {
   isWall = true;
  }
  
  if (other.CompareTag("Player"))
  {
   isFound = true;
   mTargePos = other.GetComponent<Transform>();
  }
  
 }

 private void OnTriggerStay2D(Collider2D other)
 {
  if (other.CompareTag("EnemyWall"))
  {
   isWall = true;
  }
  if (other.CompareTag("Player"))
  {
   isFound = true;
   mTargePos = other.GetComponent<Transform>();
  }
 }

 private void OnTriggerExit2D(Collider2D other)
 {
  
  if (other.CompareTag("EnemyWall"))
  {
   isWall = false;
  }

  if (other.CompareTag("Player"))
  {
   isFound = false;
  }
  
 }
}
