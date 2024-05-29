using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public AudioSource[] audioSources;  // Assign all AudioSources in the inspector

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            foreach (var audioSource in audioSources)
            {
                AudioManager.instance.RegisterAudioSource(audioSource);
            }
            Debug.Log("AudioSources registered on scene start.");
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null.");
        }
    }
}
