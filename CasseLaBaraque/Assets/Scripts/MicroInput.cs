using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* There might be some latency */
public class MicroInput : MonoBehaviour
{
    AudioClip microphoneInput;
    bool microInitialized;
    public float clipLoudness = 0f;
    int microPrecision = 128;


    void Awake()
    {
        //init micro input
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microInitialized = true;
        }
    }

    public float GetMicroLoudness()

    {

        return clipLoudness;

    }

    // Update is called once per frame
    void Update()
    {
        //initializing micro
        if (!microInitialized)
            Awake();


        //get mic volume


        int micPosition = Microphone.GetPosition(null) - (microPrecision + 1);

        //get mic volume
        float[] waveData = new float[microPrecision];
        microphoneInput.GetData(waveData, micPosition);
        clipLoudness = 0;

        foreach (var sample in waveData)
        {
            clipLoudness += Mathf.Abs(sample);
        }
        clipLoudness /= microPrecision;
    }
}
