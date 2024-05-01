using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FligtTrainingQuest : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>();
    [SerializeField] private QuestPanel questPanel;
    [SerializeField] private DirectionalArrow directionalArrow;
    //private QuestManager questManager = QuestManager.instance;
    
    private void Start()
    {
        if (directionalArrow != null)
        {
            directionalArrow.SetCheckpoints(checkpoints);
            directionalArrow.gameObject.SetActive(true);
        }
        
        QuestManager questManager = QuestManager.instance;
        if (questManager != null)
        {
            questManager.StartQuest("Entrainement de vol");
            //QuestPanel questPanel = FindObjectOfType<QuestPanel>();
            
            // ajouter le panel de quete
            if (questPanel != null)
            {
                questPanel.gameObject.SetActive(true);
                questPanel.UpdateQuestPanel(QuestManager.instance.quests[0]);
            }
            
        }
    }

    private void Update()
    {
        bool checkpointsReached = DirectionalArrow.isComplete;
        //QuestPanel questPanel = FindObjectOfType<QuestPanel>();
        QuestManager questManager = QuestManager.instance;

        if (checkpointsReached)
        {
            if (questManager!= null)
            {
                questManager.CompleteObjective("Entrainement de vol", "Trajet Entrainement");
                questPanel.gameObject.SetActive(false);
            }
        }
    }
    
}
