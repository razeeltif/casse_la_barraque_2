using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Neighbour at the window in the other building */
public class StoreNeighbour : Neighbour
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
        this.GetComponent<Animator>().Play("");
    }

    public override void CallComing()
    {
        this.GetComponent<Animator>().Play("voisin_apparition");
    }

    public override void CallDeparture()
    {
        this.GetComponent<Animator>().Play("voisin_sortie");
    }

    public override void CallTriggered()
    {
        this.GetComponent<Animator>().Play("voisin_furax");
    }

}
