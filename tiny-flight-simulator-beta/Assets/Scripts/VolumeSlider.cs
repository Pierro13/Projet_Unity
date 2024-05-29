using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            slider.value = AudioManager.instance.GetVolume();
            slider.onValueChanged.AddListener(OnSliderValueChanged);
            Debug.Log("Slider initialized with volume: " + slider.value);
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null.");
        }
    }

    private void OnSliderValueChanged(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(volume);
            Debug.Log("Slider value changed: " + volume);
        }
    }
}
