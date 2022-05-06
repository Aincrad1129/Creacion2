using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChallange : MonoBehaviour, IChallenge
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CineMachineSwitch cineMachineSwitch;
    [HideInInspector]public bool isUnlocked;

    private KillPlayer killPlayer;
    // Start is called before the first frame update
    void Start()
    {
        killPlayer = FindObjectOfType<KillPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Complete()
    {
        throw new System.NotImplementedException();
    }

    public bool getCompleted()
    {
        throw new System.NotImplementedException();
    }

    public void Restart() => killPlayer.Kill();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (isUnlocked) {
                cineMachineSwitch.animator.SetBool("WorldCamera", true);
                gameManager.finalChallengeUnloke = true;
                killPlayer.SetRespawnPoitn(respawnPoint);
            }
        }
    }


}
