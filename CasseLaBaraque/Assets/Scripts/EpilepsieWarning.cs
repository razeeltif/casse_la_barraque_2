using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilepsieWarning : MonoBehaviour
{
    enum STATE { state1, state12, state2, state23, state3, state31 };
    private STATE actualState  = STATE.state1;


    public SpriteRenderer salon;

    public float minimumValueToEpilepsy = 0.0001f;
    public float speedFactor = 100f;

    Vector3 color = new Vector3(255, 0, 0);

    private Coroutine epilepsyCoroutine;


    // Start is called before the first frame update
    void Update()
    {
     
        if(epilepsyCoroutine == null)
        {
            if(GameManager.Instance.getDbMicro() > minimumValueToEpilepsy)
            {
                startEpilepsy();
            }

        }
        else
        {
            if(GameManager.Instance.getDbMicro() < minimumValueToEpilepsy)
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

        salon.color = new Color(255, 255, 255, 255);
    }



    private IEnumerator epilepsy()
    {

        while (true)
        {

            switch (actualState)
            {
                case STATE.state1:

                    color.y += Time.deltaTime * speedFactor * GameManager.Instance.getDbMicro();

                    if (color.y >= 255)
                    {
                        actualState = STATE.state12;
                    }
                    break;


                case STATE.state12:

                    color.x -= Time.deltaTime * speedFactor * GameManager.Instance.getDbMicro();

                    if (color.x <= 0)
                    {
                        actualState = STATE.state2;
                    }
                    break;

                case STATE.state2:

                    color.z += Time.deltaTime * speedFactor * GameManager.Instance.getDbMicro();

                    if (color.z >= 255)
                    {
                        actualState = STATE.state23;
                    }
                    break;

                case STATE.state23:

                    color.y -= Time.deltaTime * speedFactor * GameManager.Instance.getDbMicro();

                    if (color.y <= 0)
                    {
                        actualState = STATE.state3;
                    }
                    break;

                case STATE.state3:

                    color.x += Time.deltaTime * speedFactor * GameManager.Instance.getDbMicro();

                    if (color.x >= 255)
                    {
                        actualState = STATE.state31;
                    }
                    break;

                case STATE.state31:

                    color.z -= Time.deltaTime * speedFactor * GameManager.Instance.getDbMicro();

                    if (color.z <= 0)
                    {
                        actualState = STATE.state1;
                    }
                    break;

            }

            salon.color = new Color(color.x, color.y, color.z, 255);
            yield return null;
        }

    }


}
