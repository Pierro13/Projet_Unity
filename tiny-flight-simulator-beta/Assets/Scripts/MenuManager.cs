using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject freeModePanel;
    public GameObject optionsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("Flight Demo");
        Time.timeScale = 1.0f;
    }
    
    public void PlayMissionsMode(){
        SceneManager.LoadScene("SceneMerge");
        Time.timeScale = 1.0f;
    }

    public void PlayFreeModeMap1(){
        SceneManager.LoadScene("Flight Demo");
        Time.timeScale = 1.0f;
    }

    public void PlayFreeModeMap2(){
        SceneManager.LoadScene("SceneLibre");
        Time.timeScale = 1.0f;
    }

    public void FreeFlightPanelsVisibility(){
        if(menuPanel != null && freeModePanel != null){
            menuPanel.SetActive(!menuPanel.activeSelf);
            freeModePanel.SetActive(!freeModePanel.activeSelf);
        }
    }

    public void OptionsPanelsVisibility(){
        if(menuPanel != null && optionsPanel != null){
            menuPanel.SetActive(!menuPanel.activeSelf);
            optionsPanel.SetActive(!optionsPanel.activeSelf);
        }
    }
}
