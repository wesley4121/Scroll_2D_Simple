using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Xml;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Random = UnityEngine.Random;

public class Enemy1 : MonoBehaviour
{
    private Enemy1 _instence;
    public float EnemyHP;
    public float FoundSpeed;
    public float KnockBack;
    public float AttackCoolTime;
    public bool isAttack;
    public bool isSerch;
    public bool mDie;
    public bool SpawnPoint;

    public TalkManages c_TalkManages;
    public Player c_Player;
    public Rigidbody2D mRigi;
    public Animator mAnimator;
    public SpriteRenderer mSpR;
    public Transform mTrans;
    public EnemyAttack c_EnemyAttack;
    public EnemySeeRange c_EnemySee;
    public EnemyAttackRange c_AttackRange;
    public GameObject Enemy,SearchOrig,SerachOBJ,mClone,Hibox,HitBox_Clone;

    public int mRandomForward;
    public float timeElapsed;
    float lerpDuration = 3;

    private void Awake()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("col");


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("tri");
        if (!TalkManages.IsTalk)
        {
            if (other.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log("triDMG");
                takeDamage(other.gameObject);
            }

            if (other.gameObject.CompareTag("Point"))
            {
                Debug.Log("triPoint");
                Destroy(other.gameObject.transform.parent.gameObject);
                Destroy(GameObject.FindWithTag("Clone"));
                isSerch = false;
                timeElapsed = 0;

            }
            
        }

    }
    

    void Update()
    {

        if (!TalkManages.IsTalk)
        {
            if (!mDie)
            {

                if (!c_AttackRange.isAttack)
                {
                    TraceingTarge(FoundSpeed);
                }

                Search();

            }
            StartCoroutine("Attack",AttackCoolTime);

            Die();
            // StartCoroutine("CheakSPoint");
        }



    }

    // public void Attack()
    // {
    //     mAnimator.SetBool("EnemyAttack",true);
    //
    // }
  private  IEnumerator Attack()
    {         

    
        if (c_AttackRange.isAttack && !isAttack )
        {
            isAttack = true;
            mAnimator.SetBool("EnemyAttack",true);
            yield return new WaitForSeconds(0.5F);
            HitBox_Clone = Instantiate(Hibox, transform.position, Quaternion.identity);
            HitBox_Clone.transform.SetParent(Enemy.transform);
            if (mTrans.position.x <= HitBox_Clone.transform.position.x)
            {
                HitBox_Clone.transform.localScale = new Vector3(1, 1, 0);
            }
            else if (mTrans.position.x >= HitBox_Clone.transform.position.x)
            {
                HitBox_Clone.transform.localScale = new Vector3(-1, 1, 0);
            }

            yield return new WaitForSeconds(0.1F);
            Destroy(HitBox_Clone);
            yield return new WaitForSeconds(1);
            mAnimator.SetBool("EnemyAttack",false);
            isAttack = false;


        }
    }
    public void TraceingTarge(float dashSpeed)
    {

            
            if (!isAttack && c_EnemySee.isFound && mTrans.position.x<c_EnemySee.mTargePos.position.x)
            {
                mTrans.Translate(Vector3.right*Time.deltaTime*FoundSpeed);
                mTrans.localScale = new Vector3(-1, 1, 0);
                isSerch = false;
                timeElapsed = 0;
                GameObject[] AllClone  = GameObject.FindGameObjectsWithTag("Clone");
                for (int i = 0; i < AllClone.Length; i++)
                {
                    Destroy(AllClone[i]);
                }
                StopCoroutine("Pointspawn");
                StopCoroutine("CheakSPoint");
            }
            if (!isAttack && c_EnemySee.isFound && mTrans.position.x>c_EnemySee.mTargePos.position.x)
            {
                mTrans.Translate(Vector3.left*Time.deltaTime*FoundSpeed);
                mTrans.localScale = new Vector3(1, 1, 0);
                isSerch = false;
                timeElapsed = 0;
                GameObject[] AllClone  = GameObject.FindGameObjectsWithTag("Clone");
                for (int i = 0; i < AllClone.Length; i++)
                {
                    Destroy(AllClone[i]);
                }
                StopCoroutine("Pointspawn");
                StopCoroutine("CheakSPoint");
            }

    }

    public void Search( )
    {

        if (!c_EnemySee.isFound)
        {
            if (!isSerch )
            {

                isSerch = true;
                StartCoroutine("Pointspawn");
            }

            if (timeElapsed < lerpDuration && mClone )
            {
                mTrans.transform.position = Vector3.Lerp(mTrans.transform.position, mClone.transform.GetChild(0).transform.position, timeElapsed / lerpDuration);
                timeElapsed += 0.5F*Time.deltaTime;
            }
        }
        
    }


    private IEnumerator CheakSPoint()
    {
        if (!SpawnPoint && isSerch && !mClone )
        {           
            print("CheakP");
            GameObject[] AllClone  = GameObject.FindGameObjectsWithTag("Clone");
            for (int i = 0; i < AllClone.Length; i++)
            {
                Destroy(AllClone[i]);
            }

            yield return new WaitForSeconds(2);
            isSerch = false;
        }
        yield break;
    }
    IEnumerator FreashPoint()
    {
        yield return new WaitForSeconds(5);
        GameObject[] AllClone  = GameObject.FindGameObjectsWithTag("Clone");
        for (int i = 0; i < AllClone.Length; i++)
        {
            Destroy(AllClone[i]);
        }
        yield break;
    }
    IEnumerator Pointspawn( )
    {
        if (!c_EnemySee.isWall)
        {
            SpawnPoint = true;
            yield return new WaitForSeconds(3);
            mRandomForward = Random.Range(1, 3);
            if ( mRandomForward == 1 )
            {
                Debug.Log("1");
                mTrans.localScale = new Vector3(-1, 1, 0);
                mClone= Instantiate(SerachOBJ, SearchOrig.transform.position, Quaternion.identity);
                mClone.GetComponent<RandomForward>().forward = mRandomForward;
            }
            else
            {
                Debug.Log("2");
                mTrans.localScale = new Vector3(1, 1, 0);
                mClone= Instantiate(SerachOBJ, SearchOrig.transform.position, Quaternion.identity);
                mClone.GetComponent<RandomForward>().forward = mRandomForward;
            }

            SpawnPoint = false;
        }
        else
        {
            print("ISWALL");
            float nowScale = mTrans.localScale.x;
 
            if (mRandomForward ==1)
            {
                mRandomForward = 2;
            }
            else
            {
                mRandomForward = 1;
            }
            int nowForward = mRandomForward;
            mTrans.localScale = new Vector3(nowScale*-1, 1, 0);
            mClone= Instantiate(SerachOBJ, SearchOrig.transform.position, Quaternion.identity);
            mClone.GetComponent<RandomForward>().forward = mRandomForward;
            SpawnPoint = false;
        }
    }
 
     public void takeDamage(GameObject Other)
     {
         Debug.Log("DMG");


         EnemyHP -= 10;
         isSerch = false;
         StartCoroutine("EnemyKnockBack", Other);
         mAnimator.SetBool("EnemyDamage",true);
         Invoke("DamageEnd",0.5F);


     }

     public void DamageEnd()
     {
         if (mTrans.position.x<c_EnemySee.mTargePos.position.x)
         {
             mTrans.localScale = new Vector3(-1, 1, 0);

         }

         if (mTrans.position.x > c_EnemySee.mTargePos.position.x)
         {

             mTrans.localScale = new Vector3(1, 1, 0);

         }
         mAnimator.SetBool("EnemyDamage",false);


     }

     public void Die()
     {
  
         if (EnemyHP<=0 && !mDie)
         {
             mRigi.constraints = RigidbodyConstraints2D.FreezeAll;
             mDie = true;
             mAnimator.SetBool("EnemyDie",true);
            Invoke("Enemydestroy",1);
           
         }
     }

     public void Enemydestroy()
     {
         Destroy(gameObject);
     }

     IEnumerator EnemyKnockBack(GameObject Other)
     {
         Rigidbody2D StartRigi = mRigi;
         if (Other.transform.position.x>=mTrans.position.x)
         {
             mRigi.AddForce(new Vector2(-1*KnockBack,0));
         }
         if (Other.transform.position.x<=mTrans.position.x)
         {
             mRigi.AddForce(new Vector2(1*KnockBack,0));
         }
         yield break;
     }

}
