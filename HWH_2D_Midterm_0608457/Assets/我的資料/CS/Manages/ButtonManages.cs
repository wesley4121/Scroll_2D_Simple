using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManages : MonoBehaviour
{
    public Player _player;

    private void Update()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Enent1");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");

    }

    public void Restart()
    {
        string NowSC = SceneManager.GetActiveScene().name;
        GameObject RestartP = GameObject.FindWithTag("Restart");
        RestartP.transform.localScale = new Vector3(0, 1, 0);
        _player.CancelInvoke("SetRestartP");
        _player.mAnimator.SetBool("Die",false);
        _player.CurPlayerHP = 100;
        _player.isDie = false;
        Destroy(_player.gameObject);
        SceneManager.LoadScene(NowSC);
        
    }
}
