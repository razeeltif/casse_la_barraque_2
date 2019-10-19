using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowThingsManager : MonoBehaviour
{

    public GameObject[] listThrowablePrefabs;

    public float timeBetweenThrow = 1f;

    public float angleProjection = 100f;

    public float multiplicatorPowerProjection = 10f;

    public float SpawnObjectsSpread = 10f;

    private List<GameObject> listThingThrown;

    private UTimer ThrowTimer;



   



    private void Awake()
    {
        listThingThrown = new List<GameObject>();

        ThrowTimer = UTimer.Initialize(timeBetweenThrow, this, ThrowObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        ThrowObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DestroyAllObjects();
        }
    }

    public void ThrowObject()
    {
        int indexThrowableObjects = Random.Range(0, listThrowablePrefabs.Length - 1);

        GameObject objectToThrow = Instantiate(listThrowablePrefabs[indexThrowableObjects]);
        listThingThrown.Add(objectToThrow);

        // set initial position
        float x = Random.Range(-SpawnObjectsSpread, SpawnObjectsSpread);
        objectToThrow.transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);

        // set force and direction of the throw
        float angle = Random.Range(-angleProjection, angleProjection);
        objectToThrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(angle, 200));

        // restart the timer
        ThrowTimer.restart();
    }

    public void DestroyAllObjects()
    {
        foreach(GameObject obj in listThingThrown)
        {
            Destroy(obj);
        }
        listThingThrown = null;
        ThrowTimer.Stop();
    }

    /* private float getPowerProjection()
     {

     }*/


    private void OnDrawGizmos()
    {
        Vector3 from = new Vector3(this.transform.position.x - SpawnObjectsSpread, this.transform.position.y, this.transform.position.z);
        Vector3 to = new Vector3(this.transform.position.x + SpawnObjectsSpread, this.transform.position.y, this.transform.position.z);
        Gizmos.DrawLine(from, to);
    }


}
