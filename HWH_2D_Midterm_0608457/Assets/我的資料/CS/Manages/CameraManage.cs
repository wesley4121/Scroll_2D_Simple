using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public CinemachineConfiner2D mCCF;
    // Start is called before the first frame update
    void Start()
    {
        mCCF = GameObject.FindWithTag("PlayerCamera").GetComponent<CinemachineConfiner2D>();

    }

    // Update is called once per frame
    void Update()
    {
        mCCF.m_BoundingShape2D = GameObject.FindWithTag("LevelBounds").GetComponent<PolygonCollider2D>();
    }
}
