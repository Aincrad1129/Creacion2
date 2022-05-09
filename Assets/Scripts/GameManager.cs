using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform startSpawnPoint;
    //[SerializeField] private List<PlayerMovement> _players = new List<PlayerMovement>();
    [SerializeField] private List<GameObject> _challenges = new List<GameObject>();
    [SerializeField] private FinalChallange finalChallenge;
    // public List<PlayerMovement> players { get => _players; }
    public List<GameObject> challenges { get => _challenges; }

    [HideInInspector]public bool finalChallengeUnloke;
    private bool _pause;
    public bool pause { get => _pause; }

    private KillPlayer killPlayer;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        killPlayer = FindObjectOfType<KillPlayer>();
        killPlayer.SetRespawnPoitn(startSpawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNewPlayer(InputAction input) {
        //index = Random.Range(0,players.Count);

    }
    public void checkChallenges() {
        
        if(challenges.TrueForAll(x => x.GetComponent<IChallenge>().getCompleted() == true)){
            finalChallenge.isUnlocked = true;
        }
    }


    public void SetFinalChallenge() {
    }
    public void setPause(bool state) {
        _pause = state;
    }
   
}

