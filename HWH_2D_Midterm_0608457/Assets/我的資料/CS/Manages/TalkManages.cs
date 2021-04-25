using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManages : MonoBehaviour
{
    public GameObject[] PenelS;
    public static bool IsTalk;

    void Update()
    {
        if (GameObject.FindWithTag("TalkPenel"))
        {
            IsTalk = true;
        }
        else
        {
            IsTalk = false;
        }
    }
}
