using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourNuitScript : MonoBehaviour
{

    public Color nuit;
    public Color jour;

    public Color ImmeubleNuit;
    public Color ImmeubleJour;



    public DifficultySettings settings;

    public SpriteRenderer[] immeubleSprites;

    private Coroutine fadeJourNuitCoroutine;


    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        fadeJourNuitCoroutine = StartCoroutine(fadeJourNuit());
    }


    private IEnumerator fadeJourNuit()
    {
        Camera.main.backgroundColor = nuit;
        float timer = 0;

        while(timer < settings.playTimeInSeconds)
        {
            float ratio = timer / settings.playTimeInSeconds;

            Color newColor = Color.Lerp(nuit, jour, ratio);


            Camera.main.backgroundColor = newColor;

            foreach(SpriteRenderer sprite in immeubleSprites)
            {
                sprite.color = Color.Lerp(ImmeubleNuit, ImmeubleJour, ratio);
            }

            timer += Time.deltaTime;
            yield return null;
        }
        
    }

    public void EndGame()
    {
        if(fadeJourNuitCoroutine != null)
        {
            StopCoroutine(fadeJourNuitCoroutine);
            fadeJourNuitCoroutine = null;
        }
    }

}
