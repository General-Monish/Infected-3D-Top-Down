using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    [SerializeField]
    private Slider slider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }

        // Subscribe to slider's value changed event
        slider.onValueChanged.AddListener(delegate { SetVolume(); });
    }

    private void Start()
    {
        Play("Pain");
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
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

    public void SetVolume()
    {
        // Update volume of all audio sources based on slider value
        foreach (Sound sound in sounds)
        {
            sound.audioSource.volume = slider.value;
        }
    }
}
