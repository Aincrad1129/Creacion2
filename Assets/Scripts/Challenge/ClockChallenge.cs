using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockChallenge : MonoBehaviour,IChallenge
{
    private bool isComplete;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Clock mainClock;
    [SerializeField] private List<Clock> clocks = new List<Clock>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CompareClock(Clock clock) {
        if (clock.seconds == mainClock.seconds)
        {
            clock.isComplete = true;
            print(clock.name + "completed");
        }
        if (clocks.TrueForAll(x => x.isComplete)) Complete();
    }
    public void Complete()
    {
        Debug.Log("Complete");
        isComplete = true;
        gameManager.checkChallenges();
    }

    public void Restart()
    {
        throw new System.NotImplementedException();
    }

    public bool getCompleted() => isComplete;

}
