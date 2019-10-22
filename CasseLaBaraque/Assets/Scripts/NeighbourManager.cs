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

    private void OnEnable()
    {
        EventManager.Detection += NeighbourTriggered;
        EventManager.BeginGame += beginNeighbour;
    }

    private void OnDisable()
    {
        EventManager.Detection -= NeighbourTriggered;
        EventManager.BeginGame -= beginNeighbour;
    }

    private void Awake()
    {
        //timer to activate immediately, the neighbour sleeps unitl the end of the timer
        timerBetweenRestSigne = UTimer.Initialize(settings.InitialTimeBetween2Checks, this, Checking);

        //timer to activate after the last one, the neighbour switch on its sign and let it visible until the end of the timer
        timerBetweenSigneComing = UTimer.Initialize(settings.InitialTimeDtection, this, Coming);

        //timer to activate after the last one, the neighbour check if the player is making some noise until the end of the timer
        timerBetweenComingDeparture = UTimer.Initialize(settings.InitialReactionTime, this, Departure);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void beginNeighbour()
    {
        randomIndex = Random.Range(0, neighbourList.Count);
        timerBetweenRestSigne.start(getTimeBetween2Checks());
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

        timerBetweenComingDeparture.start(getTimeDetection());
    }

    void Departure()
    {
        neighbourList[randomIndex].CallDeparture();
        randomIndex = Random.Range(0, neighbourList.Capacity - 1);

        EventManager.onEndingSurvey();
        timerBetweenRestSigne.start(getTimeBetween2Checks());

    }

    void NeighbourTriggered()
    {
        neighbourList[randomIndex].CallTriggered();
    }



    private float getTimeBetween2Checks()
    {
        return Random.Range(settings.InitialTimeBetween2Checks - settings.InitialRandomTimeBetween2Checks, settings.InitialTimeBetween2Checks + settings.InitialRandomTimeBetween2Checks);
    }

    private float getTimeDetection()
    {
        return Random.Range(settings.InitialTimeDtection - settings.RandomTimeDetection, settings.InitialTimeDtection + settings.RandomTimeDetection);
    }

    private float getReactionTime()
    {
        float result;
        float ratio = GameManager.Instance.timer / settings.playTimeInSeconds;

        result = Mathf.Lerp(settings.InitialReactionTime, settings.EndReactionTime, ratio);
        return result;
    }
}
