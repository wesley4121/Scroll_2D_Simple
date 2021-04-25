using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundTEST : MonoBehaviour
{
    public SpriteRenderer msPriteR;
    private float right;
    private float left;
    private float distance;
    void Start()
    {          
        msPriteR = GetComponent<SpriteRenderer>();
        right = transform.position.x + msPriteR.bounds.extents.x ;
        left = transform.position.x - msPriteR.bounds.extents.x ; 
 
        distance = right - left;//左右边界相减得到距离
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            Debug.Log("extents.x ="+msPriteR.bounds.extents.x);
            Debug.Log("size.x ="+msPriteR.bounds.size.x);
            Debug.Log("center.x ="+msPriteR.bounds.center.x);
            Debug.Log("distance ="+distance);
            Debug.Log("R = "+right);
            Debug.Log("L = " +left);
        }
    }
}
