using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowThingsManager : MonoBehaviour
{

    public GameplaySettings settings;

    public GameObject[] listThrowablePrefabs;



    private List<GameObject> listThingThrown;
    private UTimer ThrowTimer;
    private bool IsThrowing = false;



    private void Awake()
    {
        listThingThrown = new List<GameObject>();

        ThrowTimer = UTimer.Initialize(settings.timeBetweenThrow, this, ThrowObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            DestroyAllObjects();
        }

        if(!IsThrowing && GameManager.Instance.getDbMicro() > settings.minDbForThrowThings)
        {
            ThrowObject();
            IsThrowing = true;
        }

        if(GameManager.Instance.getDbMicro() < settings.minDbForThrowThings)
        {
            ThrowTimer.Stop();
            IsThrowing = false;
        }
    }



    public void ThrowObject()
    {
        int indexThrowableObjects = Random.Range(0, listThrowablePrefabs.Length - 1);

        GameObject objectToThrow = Instantiate(listThrowablePrefabs[indexThrowableObjects]);
        listThingThrown.Add(objectToThrow);

        // set initial position
        float x = Random.Range(-settings.SpawnObjectsSpread, settings.SpawnObjectsSpread);
        objectToThrow.transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);

        // set force and direction of the throw
        float angle = Random.Range(-settings.angleProjection, settings.angleProjection);
        objectToThrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(angle, getPowerProjection()));

        // restart the timer
        ThrowTimer.restart();
    }

    public void DestroyAllObjects()
    {
        foreach(GameObject obj in listThingThrown)
        {
            Destroy(obj);
        }
        listThingThrown = new List<GameObject>();
        ThrowTimer.Stop();
    }

    private float getPowerProjection()
     {
        return settings.multiplicatorPowerProjection * GameManager.Instance.getDbMicro();
     }

    private void OnDrawGizmos()
    {
        Vector3 from = new Vector3(this.transform.position.x - settings.SpawnObjectsSpread, this.transform.position.y, this.transform.position.z);
        Vector3 to = new Vector3(this.transform.position.x + settings.SpawnObjectsSpread, this.transform.position.y, this.transform.position.z);
        Gizmos.DrawLine(from, to);
    }


}
