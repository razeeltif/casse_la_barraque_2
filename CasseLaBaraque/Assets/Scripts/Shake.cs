using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Vector3 startPosition;


    public float magnitudeMultiplicator = 1;
    public float magnitudeDbMultiplicator = 1;
    public float waitingBaseTime = 0;
    public float waitingTimeMultiplicator = 1;
    public float yVariation = 1;
    public float xVariation = 1;
    public bool laFuite = false;
    public float tailleFuite = 0.5f;

    float magnitude;
    float waitingTime;
    float timeWaited;

    bool isPlaying = true;

    private void Start()
    {
        startPosition = transform.position;
        timeWaited = 0;
    }



    public void SetMagnitude(float microDb)
    {


        if (microDb <= GameManager.Instance.getDbCalme())
            magnitude = 0;
        else
            this.magnitude = microDb;
    }

    public void SetWaitingTime(float microDb)
    {
        waitingTime = waitingBaseTime * waitingTimeMultiplicator * 1 / microDb;
    }

    // Update is called once per frame 
    void Update()
    {

        if (!isPlaying)
        {
            return;
        }


        float microDb = GameManager.Instance.getDbMicro();
        SetWaitingTime(microDb);



        if (waitingTime < timeWaited)
        {
            SetMagnitude(microDb);
            if (!laFuite||magnitude!=0)
                transform.position = magnitude * magnitudeDbMultiplicator * magnitudeMultiplicator * new Vector3(Random.Range(-xVariation, xVariation), Random.Range(-yVariation, yVariation), 0) + startPosition;
            else 
                transform.position = new Vector3(0, tailleFuite, 0) + startPosition;
            timeWaited = 0;
        }
        else
            timeWaited += Time.deltaTime;
    }




    private void OnEnable()
    {
        EventManager.Detection += OnDetected;
    }

    private void OnDisable()
    {
        EventManager.Detection -= OnDetected;
    }


    private void OnDetected()
    {
        isPlaying = false;
    }
}