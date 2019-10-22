using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BeginScript : MonoBehaviour
{

    public Canvas beginCanvas;

    public UTimer timer;

    public float timeBeforeAllowBeginGame = 1f;

    private bool allowBeginGame = false;


    private void Start()
    {
        timer = UTimer.Initialize(timeBeforeAllowBeginGame, this, allow);
        timer.start();
    }

    // Update is called once per frame
    void Update()
    {
        if(allowBeginGame && GameManager.Instance.getDbMicro() > GameManager.Instance.getDbCalme())
        {
            beginCanvas.enabled = false;
            GameManager.Instance.StartGame();
            this.enabled = false;
        }
    }



    void allow()
    {
        allowBeginGame = true;
    }
}
