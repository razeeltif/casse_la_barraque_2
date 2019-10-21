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
        this.GetComponentsInChildren<Animator>()[0].Play("volet_ouverture");
    }

    public override void CallComing()
    {
        this.GetComponentsInChildren<Animator>()[1].Play("fond_voisin_arrivee");
    }

    public override void CallDeparture()
    {
        this.GetComponentsInChildren<Animator>()[0].Play("volet_fermeture");
        this.GetComponentsInChildren<Animator>()[1].Play("fond_voisin_sortie");
    }

    public override void CallTriggered()
    {
        this.GetComponentsInChildren<Animator>()[1].Play("fond_voisin_furax");
    }

}
