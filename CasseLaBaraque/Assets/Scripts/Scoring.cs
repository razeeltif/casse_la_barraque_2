using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public int score;
    float microDb;
    TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        microDb = 0;
        textMesh = GetComponent<TextMeshProUGUI>();
        Debug.Log(textMesh == null);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetInGame())
        {
            microDb = GameManager.Instance.getDbMicro();
            if (microDb > GameManager.Instance.getDbCalme())
            {
                score += (int)(microDb * 100);
                textMesh.text = "Score : " + score;
            }
        }

    }
}
