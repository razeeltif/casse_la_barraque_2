using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    int musicIndex;
    bool zero;
    public float hiddingSoundAverageSpacing;
    public float hiddingSoundSpacingSpread;
    float timeToWait;
    LightAudioManager hiddingSound;
    LightAudioManager policeSound;
    LightAudioManager grosseKali;

    // Start is called before the first frame update
    void Start()
    {
        musicIndex = 0;
        zero = true;
        timeToWait = Random.Range(-hiddingSoundSpacingSpread, hiddingSoundSpacingSpread) + hiddingSoundAverageSpacing;
        hiddingSound = GetComponents<LightAudioManager>()[0];
        policeSound = GetComponents<LightAudioManager>()[1];
        grosseKali = GetComponents<LightAudioManager>()[2];
    }

    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.getDbMicro() < GameManager.Instance.getDbCalme())
        {
            if (!zero)
            {
                grosseKali.Stop("" + musicIndex);
                zero = true;
                if (musicIndex < grosseKali.sounds.Length - 2)
                    musicIndex++;
                else
                    musicIndex = 0;

            }
            if (timeToWait <= 0)
            {
                timeToWait = Random.Range(-hiddingSoundSpacingSpread, hiddingSoundSpacingSpread) + hiddingSoundAverageSpacing;
                hiddingSound.Play(""+Random.Range(0, (int)hiddingSound.sounds.Length));
            } else
            {
                timeToWait -= Time.deltaTime;
            }

        } else if (zero)
        {
            zero = false;
            grosseKali.Play(""+musicIndex);
        } else
        {
            //rien 
        }
    }
}
