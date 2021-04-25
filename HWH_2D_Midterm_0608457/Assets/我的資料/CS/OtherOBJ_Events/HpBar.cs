using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    public  Slider mSlider ;
    public Player mPlayer;
    public float nowHP;
    public Image hpimamage;
    public Sprite full, half, zero;

    private void Start()
    {

    }

    private void Update()
    {
        mPlayer = GameObject.FindWithTag("Player").GetComponent<Player>();

        nowHP = mPlayer.CurPlayerHP;
        if (nowHP==100)
        {
            hpimamage.sprite = full;
        }
         if (nowHP<=70)
        {
            hpimamage.sprite = half;
        }
         if (nowHP <=0)
        {
            hpimamage.sprite = zero;
        }
    }

    public  void setHp(float nowHP)
    {
        mSlider.value = nowHP;
    }

    public  void setmaxHp(float maxHP)
    {
        mSlider.maxValue = maxHP;
        mSlider.value = maxHP;   
    }
}
