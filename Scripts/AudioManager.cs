using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound sound in sounds)
        {
            sound.audioSource=gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip=sound.audioClip;
            sound.audioSource.volume=sound.volume;
            sound.audioSource.pitch=sound.pitch;
            sound.audioSource.loop=sound.loop;
        }
    }

    private void Start()
    {
        Play("Pain");
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds,sound =>  sound.name==name);
        if (sound == null)
        {
            Debug.LogWarning("Sound : " + name + " not found");
            return;
        }
        else
        {
            sound.audioSource.Play();
        }
    }
}
