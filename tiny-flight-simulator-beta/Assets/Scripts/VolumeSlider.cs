using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;  // Reference to the audio source

    private void Start()
    {
        if (audioSource != null)
        {
            Debug.Log("Registering AudioSource: " + audioSource.name);
            AudioManager.instance.RegisterAudioSource(audioSource);
            InitializeSlider();
            slider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned to this VolumeSlider.");
        }
    }

    private void InitializeSlider()
    {
        // Load volume from PlayerPrefs if it exists, otherwise use current volume
        string key = "volume_" + audioSource.name;
        if (PlayerPrefs.HasKey(key))
        {
            float savedVolume = PlayerPrefs.GetFloat(key);
            audioSource.volume = savedVolume;
            slider.value = savedVolume;
            Debug.Log("Initialized slider for " + audioSource.name + " with saved volume: " + savedVolume);
        }
        else
        {
            slider.value = audioSource.volume;
            Debug.Log("Initialized slider for " + audioSource.name + " with current volume: " + audioSource.volume);
        }
    }

    public void SetVolume(float volume)
    {
        if (AudioManager.instance != null && audioSource != null)
        {
            Debug.Log("Slider value changed. Setting volume for " + audioSource.name + " to " + volume);
            AudioManager.instance.SetVolume(audioSource, volume);
            Debug.Log("Current volume for " + audioSource.name + " after setting is: " + audioSource.volume);
        }
        else
        {
            Debug.LogWarning("AudioManager instance or AudioSource is null.");
        }
    }
}
