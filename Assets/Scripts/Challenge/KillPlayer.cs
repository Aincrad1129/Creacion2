using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] GameManager gameManager;
    [Header("Respaw")]
    [Tooltip(" Object de la imagen de respawn")]
    [SerializeField] private GameObject restartUi;
    [SerializeField] private CineMachineSwitch cineMachineSwitch;
    [SerializeField] private int timeRestart;
    [SerializeField] private Consejos consejos;
    public int playerTimeRestart { get => timeRestart; }
    private bool _playerDead;
    public bool playerDead { get => _playerDead; }

    private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame      
    void Update()
    {
        
    }
    public  void Kill()
    {
        _playerDead = true; 
        gameManager.setPause(true);
        consejos.SetDialogo();
        restartUi.SetActive(true);
        cineMachineSwitch.animator.SetBool("ResetLevel", true);
        if (gameManager.finalChallenge.isUnlocked) gameManager.finalChallenge.Restart();
        //aqui va las particulars y toca darle un timepo de espera 
        Restart();
    }

    public async void Restart() {
        player.transform.position = respawnPoint.position;
        await Task.Delay(TimeSpan.FromSeconds(timeRestart));
        _playerDead = false;
        cineMachineSwitch.animator.SetBool("ResetLevel", false);
        cineMachineSwitch.animator.SetBool("WorldCamera", true);
        restartUi.SetActive(false);
        gameManager.setPause(false);

    }
    public void SetRespawnPoitn(Transform spawnPoint) => respawnPoint = spawnPoint;
}
