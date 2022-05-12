
using UnityEngine;

[System.Serializable]
public class Sounds 
{
    // Start is called before the first frame update
    public string name;
    public AudioClip clip;


    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 10f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
