using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{

    public GameObject gign;
    //public GameObject policeman;

    public float timeBeforeArrieeDesCops = 0;
    public float timeSceneGameOver = 3;

    UTimer timerCops;
    UTimer timerEndScene;

    private void OnEnable()
    {
        EventManager.Detection += OnBeginDetected;
    }

    private void OnDisable()
    {
        EventManager.Detection -= OnBeginDetected;
    }

    void Awake()
    {
        timerCops = UTimer.Initialize(timeBeforeArrieeDesCops, this, LaunchPoliceAnimation);
        timerEndScene = UTimer.Initialize(timeSceneGameOver, this, changeScene);
        
    }

    private void Start()
    {
        gign.SetActive(false);
    //    policeman.SetActive(false);
    }

    void OnBeginDetected()
    {
        timerCops.start();
    }


    void LaunchPoliceAnimation()
    {
        gign.SetActive(true);
    //    policeman.SetActive(true);
        StaticAudioManager.instance.Play("police");
        timerEndScene.start();
    }

    void changeScene()
    {
        StaticAudioManager.instance.Stop("police");
        SceneMan.Instance.LoadScene("MenuTest");
    }
}
