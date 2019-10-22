using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    int musicIndex = 0;
    bool zero;
    bool stoped;
    public float hiddingSoundAverageSpacing;
    public float hiddingSoundSpacingSpread;
    float timeToWait;
    LightAudioManager hiddingSound;
    LightAudioManager grosseKali;

    private string[] musicNames;

    private void Awake()
    {
        musicIndex = 0;
        zero = true;
        stoped = true;
        hiddingSound = GetComponents<LightAudioManager>()[0];
        grosseKali = GetComponents<LightAudioManager>()[1];
        timeToWait = Random.Range(-hiddingSoundSpacingSpread, hiddingSoundSpacingSpread) + hiddingSoundAverageSpacing;
    }

    // Start is called before the first frame update
    void Start()
    {
        musicNames = new string[grosseKali.sounds.Length];
        for(int i = 0; i < grosseKali.sounds.Length; i++)
        {
            musicNames[i] = grosseKali.sounds[i].name;
        }

        musicIndex = Random.Range(0, musicNames.Length);

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
        grosseKali.Stop(musicNames[musicIndex]);

        // on évite d'avoir la meme miusique d'un coup sur l'autre
        int newIndex;
        do
        {
            newIndex = Random.Range(0, musicNames.Length);
        } while (newIndex == musicIndex);

        musicIndex = newIndex;

        stoped = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (!GameManager.Instance.GetInGame())
        {
            return;
        }


        if (GameManager.Instance.getDbMicro() < GameManager.Instance.getDbCalme())
        {
            if (!zero)
            {
                grosseKali.Pause(musicNames[musicIndex]);
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
                grosseKali.Play(musicNames[musicIndex]);
                stoped = false;
            } else
            {
                grosseKali.Unpause(musicNames[musicIndex]);
            }
            zero = false;
        } else
        {
            //rien 
        }
    }
}
