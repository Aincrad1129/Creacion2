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
        gameManager.setPause(true);
        restartUi.SetActive(true);
        cineMachineSwitch.animator.SetBool("ResetLevel", true);
        //aqui va las particulars y toca darle un timepo de espera 
        Restart();
    }

    public async void Restart() {
        player.transform.position = respawnPoint.position;
        await Task.Delay(TimeSpan.FromSeconds(timeRestart));
        cineMachineSwitch.animator.SetBool("ResetLevel", false);
        cineMachineSwitch.animator.SetBool("WorldCamera", true);
       
        restartUi.SetActive(false);
        gameManager.setPause(false);

    }
    public void SetRespawnPoitn(Transform spawnPoint) => respawnPoint = spawnPoint;
}
