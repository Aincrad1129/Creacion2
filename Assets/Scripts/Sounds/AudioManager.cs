using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sounds[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        foreach (Sounds snd in sounds)
        {
            snd.source = gameObject.AddComponent<AudioSource>();
            snd.source.clip = snd.clip;

            snd.source.volume = snd.volume;
            snd.source.pitch = snd.pitch;
            snd.source.loop = snd.loop;
        }

    }
    // Update is called once per frame
    public void PlaySound(string clipName)
    {
 
            Sounds s = Array.Find(sounds, sound => sound.name == clipName);
            if (s == null)
            {
                Debug.LogWarning("clipName :" + s.name + " not founded");
                return;
            }
       if (!s.source.isPlaying)  s.source.Play();



    }

    public void StopSound(string clipName)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == clipName);
        if (s == null)
        {
            Debug.LogWarning("clipName :" + s.name + " not founded");
            return;
        }
        if(s.source.isPlaying)s.source.Stop();
    }

    public void PauseSound(string clipName)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == clipName);
        if (s == null)
        {
            Debug.LogWarning("clipName :" + s.name + " not founded");
            return;
        }
        if (s.source.isPlaying) s.source.Pause();
    }
    public void UnPauseSound(string clipName)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == clipName);
        if (s == null)
        {
            Debug.LogWarning("clipName :" + s.name + " not founded");
            return;
        }
        if (!s.source.isPlaying) s.source.UnPause();
    }

    public void StopAllSound()
    {
        foreach (Sounds snd in sounds)
        {
            if (snd.source.isPlaying) snd.source.Stop();
        }
    }
    public void PauseAllSound()
    {
        foreach (Sounds snd in sounds)
        {
            if (snd.source.isPlaying) snd.source.Pause();
        }
    }
    public void UnPauseAllSound()
    {
        foreach (Sounds snd in sounds)
        {
            if (!snd.source.isPlaying) snd.source.UnPause();
        }
    }
    public void SetVolume(string clipName,float volume) {
        Sounds s = Array.Find(sounds, sound => sound.name == clipName);
        if (s == null)
        {
            Debug.LogWarning("clipName :" + s.name + " not founded");
            return;
        }
        s.volume = volume;
        s.pitch = 5;
    }

}
