using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FinalMusic : MonoBehaviour
{
    public AudioSource musica;
    void Start()
    {
        musica.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            musica.Play();
        }
        else
        {
            musica.Stop();
        }
    }

}
