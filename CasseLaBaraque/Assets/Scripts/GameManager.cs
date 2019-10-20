using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameplaySettings settings;

    public static GameManager Instance;
    public MicroInput micro;
    float dbCalme;

    public bool isInDetection = false;

    public bool inGame = true;



    private void OnEnable()
    {
        EventManager.BeginSurvey += OnBeginSurvey;
        EventManager.EndingSurvey += OnEndingSurvey;
    }

    private void OnDisable()
    {
        EventManager.BeginSurvey -= OnBeginSurvey;
        EventManager.EndingSurvey -= OnEndingSurvey;
    }

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
    }

    private void Update()
    {

        Debug.Log(getDbMicro());
        // DETECTION
        if (inGame && isInDetection && getDbMicro() > dbCalme)
        {
            inGame = false;
            EventManager.onDetected();
        }

        if (getDbMicro() <= dbCalme)
            PlayHiddingSound();


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


    void OnBeginSurvey()
    {
        isInDetection = true;
    }

    void OnEndingSurvey()
    {
        isInDetection = false;
    }
}
