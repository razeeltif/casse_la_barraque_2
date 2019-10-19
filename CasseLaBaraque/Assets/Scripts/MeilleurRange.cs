using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeilleurRange : MonoBehaviour
{
    public float unMaxDeBruit = 0.03f;
    SpriteRenderer s;



    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        s.color = new Color(1f, 1f, 1f, 0f);

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.getDbMicro() > unMaxDeBruit)
        {
            s.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
