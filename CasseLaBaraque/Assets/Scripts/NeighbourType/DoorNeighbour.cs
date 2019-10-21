using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Neighbour that enter in the room */
public class DoorNeighbour : Neighbour
{
    public Animator Door;

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
        Door.Play("porte_ouverture");
    }

    public override void CallComing()
    {
        this.GetComponent<Animator>().Play("policeman_arrivee_gauche");
    }

    public override void CallDeparture()
    {
        this.GetComponent<Animator>().Play("policeman_sortie");
        Door.Play("porte_fermeture");
    }

    public override void CallTriggered()
    {
        this.GetComponent<Animator>().Play("policeman_furax");
    }

}
