using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourManager : MonoBehaviour
{
    public List<Neighbour> neighbourList;

    public DifficultySettings settings;

    int randomIndex;

    private UTimer timerBetweenRestSigne;
    private UTimer timerBetweenSigneComing;
    private UTimer timerBetweenComingDeparture;

    // Start is called before the first frame update
    void Start()
    {
        randomIndex = Random.Range(0, neighbourList.Capacity - 1);
        timerBetweenRestSigne.start();
    }

    private void Awake()
    {
        //timer to activate immediately, the neighbour sleeps unitl the end of the timer
        timerBetweenRestSigne = UTimer.Initialize(settings.InitialTimeBetween2Checks, this, Checking);

        //timer to activate after the last one, the neighbour switch on its sign and let it visible until the end of the timer
        timerBetweenSigneComing = UTimer.Initialize(settings.InitialTimeBetweenSigneCheck, this, Coming);

        //timer to activate after the last one, the neighbour check if the player is making some noise until the end of the timer
        timerBetweenComingDeparture = UTimer.Initialize(settings.InitialReactionTime, this, Departure);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Checking()
    {
        neighbourList[randomIndex].CallSign();
        timerBetweenSigneComing.start();

    }

    void Coming()
    {
        neighbourList[randomIndex].CallComing();

        EventManager.onBeginSurvey();

        timerBetweenComingDeparture.start();
    }

    void Departure()
    {
        neighbourList[randomIndex].CallDeparture();
        randomIndex = Random.Range(0, neighbourList.Capacity - 1);
        timerBetweenRestSigne.start();

    }

    private void OnEnable()
    {
        EventManager.Detection += NeighbourTriggered;
    }

    private void OnDisable()
    {
        EventManager.Detection -= NeighbourTriggered;
    }

    void NeighbourTriggered()
    {
        neighbourList[randomIndex].CallTriggered();
    }

}
