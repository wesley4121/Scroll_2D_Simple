using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRandom : MonoBehaviour
{
    public Transform m_change;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        m_change.rotation = Quaternion.Euler(Random.Range(0, 0), Random.Range(0, 0), Random.Range(0, 360));
        /* m_change.rotation = Random.rotation;*/
    }
}
