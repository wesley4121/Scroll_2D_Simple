using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public GameObject mPlayer;
    public Vector3 mStartPPos, mCurPPos;
    public float distens;
    public float speed;

    public GameObject B1_OBJ, B2_OBJ, B3_OBJ;
    public Vector3 B1pos,B2pos,B3pos;

    void Start()
    {
        mStartPPos = mPlayer.transform.position;

    }


    void Update()
    {
        distens = mCurPPos.x - mStartPPos.x; 
        mCurPPos = mPlayer.transform.position;
        // B1_OBJ.transform.position = B1pos;
        // B2_OBJ.transform.position = B2pos;
        // B3_OBJ.transform.position = B3pos;
        if (mStartPPos.x < mCurPPos.x && Input.GetKey(KeyCode.LeftArrow))
        {
            
        }
        else if(mStartPPos.x > mCurPPos.x && Input.GetKey(KeyCode.RightArrow))
        {
            
        }

    }
}