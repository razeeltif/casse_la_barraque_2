using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepQuiet : MonoBehaviour
{

    public Color lightOffColor;

    public SpriteRenderer[] objectsInShadow;

    bool surveing = false;
    bool lightOff = false;


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
        if(!lightOff && surveing && GameManager.Instance.getDbMicro() < GameManager.Instance.getDbCalme())
        {
            lightOff = true;
            foreach(SpriteRenderer sprite in objectsInShadow)
            {
                sprite.color = lightOffColor;
            }
        }
    }

    void OnBeginSurvey()
    {
        surveing = true;
    }

    void OnEndingSurvey()
    {
        surveing = false;
        lightOff = false;
        foreach (SpriteRenderer sprite in objectsInShadow)
        {
            sprite.color = new Color(1,1,1,1);
        }
    }


    void OnBeginDetected()
    {
        surveing = false;
        lightOff = false;
        foreach (SpriteRenderer sprite in objectsInShadow)
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }
}
