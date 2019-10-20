using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepQuiet : MonoBehaviour
{

    public Color lightOffColor;

    private void OnEnable()
    {
        EventManager.BeginSurvey += OnBeginSurvey;
        EventManager.EndingSurvey += OnEndingSurvey;
        EventManager.Detection += OnBeginDetected;
    }

    private void OnDisable()
    {
        EventManager.BeginSurvey -= OnBeginSurvey;
        EventManager.EndingSurvey -= OnEndingSurvey;
        EventManager.Detection -= OnBeginDetected;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBeginSurvey()
    {

    }

    void OnBeginDetected()
    {

    }

    void OnEndingSurvey()
    {

    }
}
