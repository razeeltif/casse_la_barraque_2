using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameplaySettings settings;

    public static GameManager Instance;
    public MicroInput micro;
    public float dbCalme;

    public bool isInDetection = false;

    public bool inGame;

    //class micro 

    // Start is called before the first frame update 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            dbCalme = settings.minimumDbForDetection;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }


    }

    public bool GetInGame()
    {
        return inGame;
    }

    public void StopGame()
    {
        inGame = false;
    }

    public void StartGame()
    {
        inGame = true;
    }

    private void Start()
    {
        StaticAudioManager.instance.Play("patate");
    }

    private void Update()
    {

        // DETECTION
        if (isInDetection && getDbMicro() > settings.minimumDbForDetection)
        {
            EventManager.onDetected();
        }


    }


    //db micro 
    public float getDbMicro()
    {
        return micro.GetMicroLoudness();
    }

    public float getDbCalme()
    {
        return dbCalme;
    }

    void PlayHiddingSound()
    {

    }

    void Update()
    {
        if (getDbMicro() <= dbCalme)
            PlayHiddingSound();

    }
}
