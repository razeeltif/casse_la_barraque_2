using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{

    public delegate void DetectionEvent();
    public static event DetectionEvent Detection;

    public delegate void BeginSurveyEvent();
    public static event BeginSurveyEvent BeginSurvey;

    public delegate void EndingSurveyEvent();
    public static event EndingSurveyEvent EndingSurvey;

    public static void onDetected()
    {
        Detection();
    }

    public static void onBeginSurvey()
    {
        BeginSurvey();
    }

    public static void onEndingSurvey()
    {
        EndingSurvey();
    }

}
