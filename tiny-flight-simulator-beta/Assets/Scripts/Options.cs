using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject CommandsPanel;
    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleOptionsPanel();
        }

        // Keep the game paused if either panel is active
        if (OptionsPanel.activeSelf || CommandsPanel.activeSelf)
        {
            if (!isPaused)
            {
                SetPause(true);
            }
        }
        else
        {
            if (isPaused)
            {
                SetPause(false);
            }
        }

        Debug.Log("OptionsPanel state: " + OptionsPanel.activeSelf);
        Debug.Log("CommandsPanel state: " + CommandsPanel.activeSelf);
        Debug.Log("isPaused: " + isPaused);
    }

    void ToggleOptionsPanel()
    {
        bool newState = !OptionsPanel.activeSelf;
        OptionsPanel.SetActive(newState);
        SetPause(newState || CommandsPanel.activeSelf);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }

    public void CommandsVisibility()
    {
        if (CommandsPanel != null && OptionsPanel != null)
        {
            bool newState = !CommandsPanel.activeSelf;
            CommandsPanel.SetActive(newState);
            OptionsPanel.SetActive(!newState);
            SetPause(newState || OptionsPanel.activeSelf);
        }
    }

    public void SetPause(bool pause)
    {
        isPaused = pause;
        Time.timeScale = isPaused ? 0f : 1f;
        Debug.Log("Game paused: " + isPaused);
    }
}
