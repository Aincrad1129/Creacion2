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
    [SerializeField] private Animator abrirL, abrirR;
    [SerializeField] private string AbrirPuerta;
    private AudioManager audioManager;
    // Start is called before the first frame update
    
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    void Start()
    {
         isLocked = true;
        abrirL.GetComponent<Animator>();
        abrirL.enabled = false;
        abrirR.GetComponent<Animator>();
        abrirR.enabled = false;
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
        audioManager.PlaySound(AbrirPuerta);
        abrirL.enabled = true;
        abrirR.enabled = true;
    }

    public void Restart()
    {
        throw new System.NotImplementedException();
    }

    public bool getCompleted() => isComplete;

}
