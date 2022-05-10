using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockChallenge : MonoBehaviour,IChallenge
{
    private bool isComplete;
    [SerializeField] private ClockEnergyChallenge clockEnergyChallenge;
    [SerializeField] private Clock mainClock;
    [SerializeField] private List<Clock> clocks = new List<Clock>();
    [HideInInspector]public bool isLocked = true;
    // Start is called before the first frame update
    void Start()
    {
         isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CompareClock(Clock clock) {
        if (clock.seconds == mainClock.seconds)
        {
            clock.isComplete = true;
            clock.timeText.color = Color.green;

           print(clock.name + "completed");
        }
        if (clocks.TrueForAll(x => x.isComplete)) Complete();
    }
    public void Complete()
    {
        Debug.Log("Complete");
        isComplete = true;
        clockEnergyChallenge.Complete();
    }

    public void Restart()
    {
        throw new System.NotImplementedException();
    }

    public bool getCompleted() => isComplete;

}
