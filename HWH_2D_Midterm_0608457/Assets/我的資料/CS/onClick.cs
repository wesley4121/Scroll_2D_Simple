using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    public Transform spawnPos;
    public onClick c_click;
    public SetIcon c_setIcon;
    public GameObject[] SpawnS;
    public AudioSource ClickSound;
    public bool bl_onClick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if (c_setIcon.IconON )
        {
            SpawnOBJ();

            ClickSound.Play();
        }
        
    }

    public void SpawnOBJ()
    {
        if (c_setIcon.IconON)
        {
            Quaternion pos = spawnPos.rotation;
                print("Yes");
                var r = Random.Range(0, 3);
                GameObject clone = Instantiate(SpawnS[r], spawnPos.position,pos );

        }
    }
}
