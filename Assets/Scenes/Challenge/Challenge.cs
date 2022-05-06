using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Challenge : MonoBehaviour, IChallenge
{
    [SerializeField] public string levelName;
    [SerializeField] private Vector3 StarSpawpnPoitn;
    [SerializeField] private Vector3 EndSpawpnPoitn;
    public bool levelComplete = false;
    private GameManager gameManager => FindObjectOfType<GameManager>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   

    }
    public void Complete() {
        levelComplete = true;
    }
    public void Restart() { 
    }
    public void KillCharacter()
    {
        //if (player.character.isAlive) player.character.isAlive = false;
        //if (gameManager.players.TrueForAll(x => !x.character.isAlive)) Restart();
    }

}




