using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerZone : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            killPlayer.Kill();
        }
    }
}
