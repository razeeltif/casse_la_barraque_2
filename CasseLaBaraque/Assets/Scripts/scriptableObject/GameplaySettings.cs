using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scripts settings/Gameplay Settings")]
public class GameplaySettings : ScriptableObject
{

    [Range(0, 5)]
    public float minimumDbForDetection = 0.001f;


    [Header("Throw things")]
    [Range(0, 5)]
    public float minDbForThrowThings = 0.01f;

    [Range(0.001f, 10)]
    public float timeBetweenThrow = 1f;

    [Range(0, 1000)]
    public float angleProjection = 100f;

    [Range(0, 100000)]
    public float multiplicatorPowerProjection = 5000f;

    [Range(0, 10)]
    public float SpawnObjectsSpread = 3.3f;



    [Header("Epilepsy warning")]
    [Range(0, 5)]
    public float DbForEpilepsy = 0.01f;

    public float speedFactor = 100f;




    private void OnValidate()
    {

        if(DbForEpilepsy < minimumDbForDetection)
        {
            DbForEpilepsy = minimumDbForDetection;
        }

        if(minDbForThrowThings < minimumDbForDetection)
        {
            minDbForThrowThings = minimumDbForDetection;
        }

    }

}
