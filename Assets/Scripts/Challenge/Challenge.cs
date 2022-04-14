using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Challenge : MonoBehaviour, IChallenge<PlayerMovement[],Vector3>
{

    private GameManager gameManager => FindObjectOfType<GameManager>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Complete(PlayerMovement[] players,Vector3 postion) {
    }
    public void Restart(PlayerMovement[] players, Vector3 postion) { 
    }
}




