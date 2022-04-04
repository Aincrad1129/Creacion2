using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    int index = 0;
    [SerializeField] private List<GameObject> players = new List<GameObject>();
    PlayerInputManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<PlayerInputManager>();
        index = Random.Range(0, players.Count);
        manager.playerPrefab = players[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNewPlayer(InputAction input) {
        index = Random.Range(0,players.Count);
        manager.playerPrefab = players[index];
    }
}
