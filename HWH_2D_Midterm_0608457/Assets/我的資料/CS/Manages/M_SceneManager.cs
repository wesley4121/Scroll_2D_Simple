using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_SceneManager : MonoBehaviour
{
    public static  M_SceneManager _instence;
    public Player _player;
    public Enemy1 _Enemy1;
    public Enemy2 _Enemy2;
    public PlayerPos _PlayerStartPos;


    private void Awake()
    {

            _instence = this;


  


    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
        _Enemy1 = GameObject.FindWithTag("Enemy").GetComponent<Enemy1>();
        _Enemy2 = GameObject.FindWithTag("Enemy").GetComponent<Enemy2>();
        _PlayerStartPos = GameObject.FindWithTag("PlayerStartPos").GetComponent<PlayerPos>();   
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("OK");
  
            print(_player);

        }
    }

    public void RestartScene()
    {

        
    }
}
