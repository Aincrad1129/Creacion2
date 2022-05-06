using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    int index = 0;
    //[SerializeField] private List<PlayerMovement> _players = new List<PlayerMovement>();
    [SerializeField] private List<Challenge> _challenges = new List<Challenge>();
   // public List<PlayerMovement> players { get => _players; }
    public List<Challenge> challenges { get => _challenges; }
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNewPlayer(InputAction input) {
        //index = Random.Range(0,players.Count);

    }
    public void checkChallenges() {
        if(challenges.TrueForAll(x => x.getCompleted() == true)){
            Debug.Log("Unlock Final Level");
        }
    }
}

