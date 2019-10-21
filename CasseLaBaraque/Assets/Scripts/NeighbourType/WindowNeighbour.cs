using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Neighbour at the widow in the bottom-right corner */
public class WindowNeighbour : Neighbour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CallSign()
    {
        this.GetComponent<Animator>().Play("New Animation");
    }

    public override void CallComing()
    {
        this.GetComponent<Animator>().Play("voisin_apparition");
    }

    public override void CallDeparture()
    {
        this.GetComponent<Animator>().Play("voisin_disparition");
    }

    public override void CallTriggered()
    {
        this.GetComponent<Animator>().Play("voisin_furax");
    }
}
