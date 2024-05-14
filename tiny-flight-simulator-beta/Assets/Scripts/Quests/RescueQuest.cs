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
        if(questManager != null)
        {
            questManager.StartQuest("Sauvetage");
            _quest = questManager.GetQuest("Sauvetage");
            
            if(questPanel != null)
            {
                questPanel.gameObject.SetActive(true);
                questPanel.UpdateQuestPanel(_quest);
            }
        }
    }

    private void Update()
    {
        QuestManager questManager = QuestManager.instance;
        bool checkpointsReached = DirectionalArrow.isComplete;
        
        if(questManager != null)
        {
            if(checkpointsReached)
            {
                questManager.CompleteObjective("Sauvetage", "Secourir les aventuriers");
                questPanel.UpdateQuestPanel(_quest);
            }
            
            // aller retour à l'aeroport sauvetage
            // attérissage puis 
        }
    }
}
