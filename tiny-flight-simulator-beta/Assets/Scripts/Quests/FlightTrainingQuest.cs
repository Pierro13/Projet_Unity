using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plane = MFlight.Demo.Plane;

public class FligtTrainingQuest : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints;
    [SerializeField] private QuestPanel questPanel;
    [SerializeField] private DirectionalArrow directionalArrow;
    //private QuestManager questManager = QuestManager.instance;
    private Quest _quest;
    
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
            _quest = questManager.GetQuest("Entrainement de vol");
            // ajouter le panel de quete
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
        bool checkpointsReached = DirectionalArrow.isComplete;
        Plane playerPlane = FindObjectOfType<Plane>();
        //Plane playerPlane = GameObject.FindGameObjectWithTag("Player").GetComponent<Plane>();
        float playerSpeed = playerPlane.GetComponent<Rigidbody>().velocity.magnitude;
        bool isPlayerFlying = false;
        
        if (questManager!= null)
        {
            if(playerSpeed > 0.1f)
            {
                questManager.CompleteObjective("Entrainement de vol", "Démarrer le moteur et décoller");
                questPanel.UpdateQuestPanel(_quest);
                isPlayerFlying = true;
            }
            
            if (checkpointsReached)
            {
                questManager.CompleteObjective("Entrainement de vol", "Suivre le trajet d'entrainement");
                questPanel.UpdateQuestPanel(_quest);
                //questPanel.gameObject.SetActive(false);
            }
            
            // if(checkpointsReached && isPlayerFlying)
            // {
            //     questPanel.gameObject.SetActive(false);
            // }
        }
    }
}
