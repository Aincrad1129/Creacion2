using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchChallenge : MonoBehaviour, IChallenge
{
    private bool isComplete;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<Switch> switches = new List<Switch>();
    // Start is called before the first frame update
    void Start()
    {
        CheckRandomState();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckRandomState()
    {
        if (switches.TrueForAll(x => x.state == true)) switches.ForEach(x => x.randomState());
    }
    public void Check()
    {
        if (switches.TrueForAll(x => x.isChanging == false && x.state == true)) Complete();
    }
    public void SetState(GameObject gameObject)
    {
        switches.ForEach(x => x.isChanging = true);
        switches.ForEach(x => x.setState(gameObject));
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

