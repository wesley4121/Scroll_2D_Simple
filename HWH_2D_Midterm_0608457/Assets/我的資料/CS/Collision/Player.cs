using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float StartSpeed;//紀錄開場的移動速度
    public float moveSpeed;//移動速度
    public float AttackMoveSpeed;//攻擊時的移動速度
    public float jumpForce;//跳躍力
    public float Player_HP;//玩家血量
    public float CurPlayerHP;//目前血量(不用調整)
    public float AttackCoolDown;
    public float KnockBack;
    public bool isDie;
    public bool isDamage;
    public bool IsAttack;
    public GameObject RestartPenel;
    public TalkManages c_TalkManages;
    public Player _intance;//這個Class(C#)
    public Transform AttackPos;//子彈位置
    public Animator mAnimator;//玩家
    public Transform mTransfeom;//玩家
    public Rigidbody2D mRigibody;//玩家
    public OnGround mOnground;//腳下觸發器
    public HpBar mHpBar;//GUI血量條
    

    private void Awake()
    {

        StartSpeed = moveSpeed;
        _intance = this;
    }

    void Start()
    {
        mHpBar = GameObject.Find("HpBar").GetComponent<HpBar>();
        mHpBar.setmaxHp(Player_HP);
        CurPlayerHP = Player_HP;
    }



    void Update()
    {

        PlayetDie();

        if (!isDie)
        {
            PlayerInput(moveSpeed,jumpForce);
        }

    }

    public void PlayerInput(float MoveSpeed ,float JumpForce)//玩家輸入
    {

        if (!TalkManages.IsTalk)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {

                transform.Translate(MoveSpeed*Vector3.right*Time.deltaTime);//右鍵
                mAnimator.SetBool("Run",true);
                mTransfeom.localScale = new Vector3(1, 1, 0);

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                transform.Translate(MoveSpeed*Vector3.left*Time.deltaTime);//左鍵
                mAnimator.SetBool("Run",true);
                mTransfeom.localScale = new Vector3(-1, 1, 0);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {

                transform.Translate(MoveSpeed*Vector3.right*Time.deltaTime);//右鍵放開
                mAnimator.SetBool("Run",false);
                mTransfeom.localScale = new Vector3(1, 1, 0);

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {

                transform.Translate(MoveSpeed*Vector3.left*Time.deltaTime);//左鍵放開
                mAnimator.SetBool("Run",false);
                mTransfeom.localScale = new Vector3(-1, 1, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow)&&mOnground._OnGround)//上鍵
            {
                mRigibody.velocity = Vector2.up * JumpForce;
            }

            if (Input.GetKeyDown(KeyCode.Z) && !IsInvoking("AttackEnd"))//攻擊
            {
                PlayerAttack(AttackCoolDown,AttackMoveSpeed);     

            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                TakeDamage(100);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("Level2");
            }
            
        }
        

 
    }

    public void TakeDamage(float DMG)//受傷
    {
        CurPlayerHP -= DMG;
        mHpBar.setHp(CurPlayerHP);

    }

    public void PlayerAttack(float AttackCoolDown,float ATKSpeed)//攻擊動畫
    {
        moveSpeed = ATKSpeed;
        
        IsAttack = true;
        mAnimator.SetBool("Attack",true); 
        Invoke("AttackEnd",AttackCoolDown);
    }
    public void AttackEnd( )
    {
        moveSpeed = StartSpeed;
        IsAttack = false;
        mAnimator.SetBool("Attack",false);
        mAnimator.SetBool("Run",false);

    }
    public void Shot(GameObject bullet)//射擊(AnimationEvent)
    {

       GameObject clone = Instantiate(bullet, AttackPos.position, Quaternion.identity);
       if (mTransfeom.transform.localScale.x < 0)
       {
           clone.transform.rotation = Quaternion.Euler(0,0,180);
       }
       else if (mTransfeom.transform.localScale.x > 0)
       {
           clone.transform.rotation = Quaternion.Euler(0,0,0);
       }


    }

    public void PlayetDie()
    {
        if (CurPlayerHP <= 0)
        {
            
            isDie = true;
            mAnimator.SetBool("Die", true);

            if (!IsInvoking("SetRestartP"))
            {
                Invoke("SetRestartP",2);
            }
        }
    }

    public void SetRestartP()
    {
        RestartPenel = GameObject.FindWithTag("Restart");
        RestartPenel.transform.localScale = new Vector3(1, 1, 0);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!TalkManages.IsTalk)
        {
            if (other.gameObject.CompareTag("Enemy") && !isDamage)
            {
                isDamage = true;
                TakeDamage(10);
                mAnimator.SetBool("Damage",true);
                Invoke("DamageEnd",0.2F);
                if (other.transform.position.x>=mTransfeom.position.x)
                {
                    mRigibody.AddForce(Vector3.left*KnockBack);
                }
                else
                {
                    mRigibody.AddForce(Vector3.right*KnockBack);
                }
            }

            if (other.gameObject.CompareTag("EnemyAttack") && !isDamage)
            {
                isDamage = true;
                TakeDamage(20);
                mAnimator.SetBool("Damage",true);
                Invoke("DamageEnd",0.2F);
                if (other.transform.position.x>=mTransfeom.position.x)
                {
                    mRigibody.AddForce(new Vector2(-1*KnockBack,0));
                }
                else
                {
                    mRigibody.AddForce(new Vector2(1*KnockBack,0));
                }
            }
        }
        
    }

    public void DamageEnd()
    {
        mAnimator.SetBool("Damage",false);
        isDamage = false;
    }



}
