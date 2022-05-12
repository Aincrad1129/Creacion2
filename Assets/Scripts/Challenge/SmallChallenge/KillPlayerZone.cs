using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerZone : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private KillPlayer killPlayer;
    [SerializeField] private string SoundName;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        killPlayer = FindObjectOfType<KillPlayer>();
        //audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            killPlayer.Kill();
        }
        else
        {
            //audioManager.PlaySound(SoundName);
        }
    }
}
