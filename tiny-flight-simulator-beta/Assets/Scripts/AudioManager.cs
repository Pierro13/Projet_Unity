using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private float globalVolume = 1f;  // Default volume is 1 (100%)

    private List<AudioSource> audioSources;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSources = new List<AudioSource>();
            LoadVolume();
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
            ApplyVolume(source);
            Debug.Log("AudioSource registered: " + source.name);
        }
    }

    public void SetVolume(float volume)
    {
        globalVolume = volume;
        PlayerPrefs.SetFloat("globalVolume", volume);
        ApplyVolumeToAll();
        Debug.Log("Global volume set to " + volume);
    }

    public float GetVolume()
    {
        return globalVolume;
    }

    private void ApplyVolume(AudioSource source)
    {
        if (source != null)
        {
            source.volume = globalVolume;
            Debug.Log("Applied global volume to " + source.name + ": " + globalVolume);
        }
    }

    private void ApplyVolumeToAll()
    {
        foreach (var source in audioSources)
        {
            ApplyVolume(source);
        }
    }

    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("globalVolume"))
        {
            globalVolume = PlayerPrefs.GetFloat("globalVolume");
            Debug.Log("Loaded global volume: " + globalVolume);
        }
    }
}
