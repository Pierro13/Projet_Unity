using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionQuest : MonoBehaviour
{
    [SerializeField] private Transform checkpoint;
    [SerializeField] private QuestPanel questPanel;
    [SerializeField] private DirectionalArrow directionalArrow;
    private Quest _quest;
    
    private void Start()
    {
        if (directionalArrow != null)
        {
            directionalArrow.SetCheckpoints(new List<Transform> {checkpoint});
            directionalArrow.gameObject.SetActive(true);
        }
        
        QuestManager questManager = QuestManager.instance;
        if (questManager != null)
        {
            questManager.StartQuest("Quête de transition");
            _quest = questManager.GetQuest("Quête de transition");
            
            if (questPanel != null)
            {
                questPanel.gameObject.SetActive(true);
                questPanel.UpdateQuestPanel(_quest);
            }
        }
    }

    private void Update()
    {
        QuestManager questManager = QuestManager.instance;
        bool checkpointReached = DirectionalArrow.isComplete;
        
        if (questManager != null)
        {
            if (checkpointReached)
            {
                questManager.CompleteObjective("Quête de transition", "Atteindre l'objectif");
                questPanel.UpdateQuestPanel(_quest);
            }
        }
    }
}
