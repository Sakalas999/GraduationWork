using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] sounds;

    void Awake()
    {
        Instance = this;

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
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        Play(LocationMusic());
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public String LocationMusic()
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
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            return "Game Over";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            return "Game Won";
        }
        else
        {
            return "Main Menu Theme";
        }
    }
}
