using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    int musicIndex;
    bool zero;
    bool stoped;
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
        stoped = true;
        timeToWait = Random.Range(-hiddingSoundSpacingSpread, hiddingSoundSpacingSpread) + hiddingSoundAverageSpacing;
        hiddingSound = GetComponents<LightAudioManager>()[0];
        policeSound = GetComponents<LightAudioManager>()[1];
        grosseKali = GetComponents<LightAudioManager>()[2];
    }

    private void OnEnable()
    {
        EventManager.EndingSurvey += YaLesVoisinsQuiPartent;
    }

    private void OnDisable()
    {
        EventManager.EndingSurvey -= YaLesVoisinsQuiPartent;
    }

    void YaLesVoisinsQuiPartent()
    {
        grosseKali.Stop("" + musicIndex);
        if (musicIndex < grosseKali.sounds.Length - 2)
            musicIndex++;
        else
            musicIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.getDbMicro() < GameManager.Instance.getDbCalme())
        {
            if (!zero)
            {
                grosseKali.Pause("" + musicIndex);
                zero = true;
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
            if (stoped)
            {
                grosseKali.Play("" + musicIndex);
                stoped = false;
            }
            zero = false;
            grosseKali.Unpause(""+musicIndex);
        } else
        {
            //rien 
        }
    }
}
