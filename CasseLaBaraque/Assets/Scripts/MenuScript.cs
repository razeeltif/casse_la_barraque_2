using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public Canvas menuPrincipal;
    public Canvas credit;
   

    public void OnClickPlay()
    {
        SceneMan.Instance.LoadScene("Graph");
    }

    public void OnClickCredit()
    {
        menuPrincipal.gameObject.SetActive(false);
        credit.gameObject.SetActive(true);
    }

    public void OnClickReturn()
    {
        menuPrincipal.gameObject.SetActive(true);
        credit.gameObject.SetActive(false);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickUseless()
    {

    }

}
