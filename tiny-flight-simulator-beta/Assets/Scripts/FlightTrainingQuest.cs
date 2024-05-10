using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plane = MFlight.Demo.Plane;

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
        QuestManager questManager = QuestManager.instance;
        bool checkpointsReached = DirectionalArrow.isComplete;
        Plane playerPlane = FindObjectOfType<Plane>();
        //Plane playerPlane = GameObject.FindGameObjectWithTag("Player").GetComponent<Plane>();
        float playerSpeed = playerPlane.GetComponent<Rigidbody>().velocity.magnitude;
        
        if (questManager!= null)
        {
            if(playerSpeed > 0.1f)
            {
                questManager.CompleteObjective("Entrainement de vol", "Démarrer le moteur et décoller");
                questPanel.UpdateQuestPanel(QuestManager.instance.quests[0]);
            }
            
            if (checkpointsReached)
            {
                questManager.CompleteObjective("Entrainement de vol", "Trajet Entrainement");
                questPanel.UpdateQuestPanel(QuestManager.instance.quests[0]);
                //questPanel.gameObject.SetActive(false);
            }
        }
    }
}
