using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceAgainstTime : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints;
    [SerializeField] private QuestPanel questPanel;
    [SerializeField] private DirectionalArrow directionalArrow;
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
            questManager.StartQuest("Course contre la montre");
            _quest = questManager.GetQuest("Course contre la montre");
            
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
        Timer timer = FindObjectOfType<Timer>();
        
        if (questManager != null)
        {
            if (checkpointsReached && timer.isTimerRunning)
            {
                questManager.CompleteObjective("Course contre la montre", "Finir la course");
                questPanel.UpdateQuestPanel(_quest);
            }
            else if (!timer.isTimerRunning)
            {
                questManager.failObjective("Course contre la montre", "Finir la course");
                questPanel.UpdateQuestPanel(_quest);
            }
        }
    }
}
