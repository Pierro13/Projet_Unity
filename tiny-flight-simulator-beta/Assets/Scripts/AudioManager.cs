using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private List<AudioSource> audioSources;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSources = new List<AudioSource>();
            Debug.Log("AudioManager initialized.");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterAudioSource(AudioSource source)
    {
        if (!audioSources.Contains(source))
        {
            audioSources.Add(source);
            Debug.Log("AudioSource registered: " + source.name);
            // Load volume from PlayerPrefs if it exists
            string key = "volume_" + source.name;
            if (PlayerPrefs.HasKey(key))
            {
                float volume = PlayerPrefs.GetFloat(key);
                source.volume = volume;
                Debug.Log("Loaded volume for " + source.name + ": " + volume);
            }
        }
    }

    public void SetVolume(AudioSource source, float volume)
    {
        if (audioSources.Contains(source))
        {
            source.volume = volume;
            string key = "volume_" + source.name;
            PlayerPrefs.SetFloat(key, volume);
            Debug.Log("Setting volume for " + source.name + " to " + volume);
            Debug.Log("Current volume for " + source.name + " is now: " + source.volume);
        }
        else
        {
            Debug.LogWarning("AudioSource not found: " + source.name);
        }
    }

    public float GetVolume(AudioSource source)
    {
        if (audioSources.Contains(source))
        {
            Debug.Log("Getting volume for " + source.name + ": " + source.volume);
            return source.volume;
        }
        Debug.LogWarning("AudioSource not found: " + source.name);
        return 1f; // Default volume
    }
}
