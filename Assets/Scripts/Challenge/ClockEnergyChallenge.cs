using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClockEnergyChallenge : MonoBehaviour, IChallenge
{
    private bool isComplete;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ClockChallenge clockChallenge;
    [SerializeField] private SwitchChallenge switchChallenge;
    [SerializeField] private List<FieldOfViewDetec> fieldOfViewDetec = new List<FieldOfViewDetec>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Complete()
    {
        if (clockChallenge.getCompleted() && switchChallenge.getCompleted())
        {
            Debug.Log("Complete:" + GetType().Name);
            isComplete = true;
            gameManager.checkChallenges();
        }
    }

    public void Restart()
    {
        throw new System.NotImplementedException();
    }
    public void UnlockClocks() {
        clockChallenge.isLocked = false;
        fieldOfViewDetec.ForEach(x => x.SwitchOn_OFFCamera(false));
    }
    public bool getCompleted() => isComplete;
}
