using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpawnSYS : MonoBehaviour
{
    public GameObject m_ORG;
    public GameObject m_rotationOBJ;



    void Start()
    {
        InvokeRepeating("Swawn", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Swawn()
    {

       
        Instantiate(m_rotationOBJ, m_ORG.transform.position , m_rotationOBJ.transform.rotation);
    }
}
