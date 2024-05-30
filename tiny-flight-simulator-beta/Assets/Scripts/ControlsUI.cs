using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsUI : MonoBehaviour
{
    [SerializeField] private GameObject controlsPanel;
    
    private void Start()
    {
        controlsPanel.gameObject.SetActive(true);
        ShowControls();
    }

    private void Update()
    {
        if (Input.anyKeyDown && controlsPanel.activeSelf)
        {
            HideControls();
        }
    }

    public void ShowControls()
    {
        if(controlsPanel != null) controlsPanel.SetActive(true);
    }
    
    public void HideControls()
    {
        if(controlsPanel != null) controlsPanel.SetActive(false);
    }
}
