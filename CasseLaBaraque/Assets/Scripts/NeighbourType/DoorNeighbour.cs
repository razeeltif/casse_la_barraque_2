using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Neighbour that enter in the room */
public class DoorNeighbour : Neighbour
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
        this.GetComponent<Animator>().Play("policeman_arrivee");
    }

    public override void CallDeparture()
    {
        this.GetComponent<Animator>().Play("policeman_sortie");
    }

    public override void CallTriggered()
    {
        this.GetComponent<Animator>().Play("policeman_furax");
    }

}
