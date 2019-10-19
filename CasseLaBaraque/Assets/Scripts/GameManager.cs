using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MicroInput micro;
    public float dbCalme = 0.01f;

    public float debugMic;

    //class micro 

    // Start is called before the first frame update 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }


    }

    //db micro 
    public float getDbMicro()
    {
        debugMic = micro.GetMicroLoudness();
        return micro.GetMicroLoudness();
    }

    public float getDbCalme()
    {
        return dbCalme;
    }
}
