using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public string initialSceneName = "Menu";  // Replace with your initial scene name

    void Start()
    {
        // Load the initial scene if it's not already loaded
        if (SceneManager.GetActiveScene().name != initialSceneName)
        {
            SceneManager.LoadScene(initialSceneName);
        }
    }
}
