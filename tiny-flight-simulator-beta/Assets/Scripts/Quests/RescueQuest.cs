using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueQuest : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints;
    [SerializeField] private QuestPanel questPanel;
    [SerializeField] private DirectionalArrow directionalArrow;
    private Quest _quest;
    
    private void Start()
    {
        if(directionalArrow != null)
        {
            directionalArrow.SetCheckpoints(checkpoints);
            directionalArrow.gameObject.SetActive(true);
        }
        
        QuestManager questManager = QuestManager.instance;
    }

    private void Update()
    {
        
    }
}
