using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Flight Demo");
        Time.timeScale = 1.0f;
    }
    
    public void PlayMissionsMode(){
        SceneManager.LoadScene("SceneMerge");
        Time.timeScale = 1.0f;
    }
}
