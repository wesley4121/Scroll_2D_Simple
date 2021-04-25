using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForward : MonoBehaviour
{

    public int forward;




    private void Update()
    {
        if (forward ==1)
        {
            transform.rotation=Quaternion.Euler(0,0,0);
        }

        if (forward==2)
        {
            transform.rotation=Quaternion.Euler(0,0,-180);
        }
    }


}
