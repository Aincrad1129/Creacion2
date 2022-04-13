
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;
    public bool die=true;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            die = false;
        }
        Die();
    }

    void Die()
    {
        if (die == false)
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
