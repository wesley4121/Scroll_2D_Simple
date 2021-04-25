using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{    
    public bool SetDone;
    public GameObject Player;
    public string SCname;

    void Start()
    {
        
    }

    void Update()
    {
        SetPlayerPos();
    }
    public void SetPlayerPos()
    {

        
         SCname = SceneManager.GetActiveScene().name;
         GameObject _player = GameObject.FindWithTag("Player");
        if (SCname!="Menu" && !_player)
        {
            GameObject clone = Instantiate(Player,transform.position, Quaternion.identity);
            SetDone = true;
        }
  
    }
}
