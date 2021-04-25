using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyAttack : MonoBehaviour
{
    public GameObject m_TargetPS;
    public GameObject m_rotationOBJ;
    public GameObject m_Clone ;
    public bool onDash;
    


    public GameObject m_Start;
    public float timeElapsed;
    float lerpDuration = 3;
    public float firstSpeed;
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        AttackDash();
    }
    void AttackDash()
    {


        if (!onDash)
        {
            onDash = true;
            m_Clone = Instantiate(m_rotationOBJ, m_TargetPS.transform.position, m_rotationOBJ.transform.rotation);

        }



        if (timeElapsed < lerpDuration)
        {
            m_Start.transform.position = Vector3.Lerp(m_Start.transform.position, m_Clone.transform.GetChild(0).transform.position, timeElapsed / lerpDuration);
            timeElapsed += 0.5F*Time.deltaTime;
        }

    }
 


}
