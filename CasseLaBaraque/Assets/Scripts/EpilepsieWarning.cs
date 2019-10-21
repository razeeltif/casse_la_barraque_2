using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilepsieWarning : MonoBehaviour
{
    enum STATE { state1, state12, state2, state23, state3, state31 };
    private STATE actualState  = STATE.state1;


    public SpriteRenderer salon;
    public GameplaySettings settings;

    Vector3 color = new Vector3(1, 0, 0);

    private Coroutine epilepsyCoroutine;

    public bool isPlaying = true;


    private void OnEnable()
    {
        EventManager.Detection += OnDetected;
    }

    private void OnDisable()
    {
        EventManager.Detection -= OnDetected;
    }


    // Start is called before the first frame update
    void Update()
    {

        if (!isPlaying)
        {
            return;
        }
     
        if(epilepsyCoroutine == null)
        {
            if(GameManager.Instance.getDbMicro() > settings.DbForEpilepsy)
            {
                startEpilepsy();
            }

        }
        else
        {
            if(GameManager.Instance.getDbMicro() < settings.DbForEpilepsy)
            {
                stopEpilepsy();
            }
        }

    }


    public void startEpilepsy()
    {
        epilepsyCoroutine = StartCoroutine(epilepsy());
    }

    public void stopEpilepsy()
    {
        StopCoroutine(epilepsyCoroutine);

        epilepsyCoroutine = null;

        salon.color = new Color(1, 1, 1, 1);
    }



    private IEnumerator epilepsy()
    {

        while (true)
        {

            switch (actualState)
            {
                case STATE.state1:

                    color.y += Time.deltaTime * settings.speedFactor * GameManager.Instance.getDbMicro();

                    if (color.y >= 1)
                    {
                        actualState = STATE.state12;
                    }
                    break;


                case STATE.state12:

                    color.x -= Time.deltaTime * settings.speedFactor * GameManager.Instance.getDbMicro();

                    if (color.x <= 0)
                    {
                        actualState = STATE.state2;
                    }
                    break;

                case STATE.state2:

                    color.z += Time.deltaTime * settings.speedFactor * GameManager.Instance.getDbMicro();

                    if (color.z >= 1)
                    {
                        actualState = STATE.state23;
                    }
                    break;

                case STATE.state23:

                    color.y -= Time.deltaTime * settings.speedFactor * GameManager.Instance.getDbMicro();

                    if (color.y <= 0)
                    {
                        actualState = STATE.state3;
                    }
                    break;

                case STATE.state3:

                    color.x += Time.deltaTime * settings.speedFactor * GameManager.Instance.getDbMicro();

                    if (color.x >= 1)
                    {
                        actualState = STATE.state31;
                    }
                    break;

                case STATE.state31:

                    color.z -= Time.deltaTime * settings.speedFactor * GameManager.Instance.getDbMicro();

                    if (color.z <= 0)
                    {
                        actualState = STATE.state1;
                    }
                    break;

            }

            salon.color = new Color(color.x, color.y, color.z, 1);
            yield return null;
        }

    }

    public void OnDetected()
    {
        isPlaying = false;
        stopEpilepsy();
    }


}
