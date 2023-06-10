using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        Play(LocationMusic());
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    private String LocationMusic()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            return "Map Theme";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            return "Batlle Theme";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            return "Base Theme";
        }
        else
        {
            return "Main Menu Theme";
        }
    }

    public void PlaySoundEffect (string name)
    {
        if (name == "Clicking")
        {

        }
        else if (name == "Event popup")
        {

        }
        else if (name == "attack")
        {

        }
    }

}
