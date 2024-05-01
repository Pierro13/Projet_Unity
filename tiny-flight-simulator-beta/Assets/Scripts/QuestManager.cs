using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> quests = new List<Quest>();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //Destroy(this);
            Destroy(gameObject);
        }
    }
    
    public void StartQuest(string questName)
    {
        Quest quest = quests.Find(x => x.questName == questName);
        if (quest != null)
        {
            quest.StartQuest();
        }
        else
        {
            Debug.LogWarning("Quest " + questName + " not found");
        }
    }
    
    public void CompleteObjective(string questName, string objectiveName)
    {
        Quest quest = quests.Find(x => x.questName == questName);
        if (quest != null)
        {
            quest.CompleteObjective(objectiveName);
        }
        else
        {
            Debug.LogWarning("Quest " + questName + " not found");
        }
    }
    
    /*public void AddQuest(string questName, string questDescription, int questReward)
    {
        Quest newQuest = new Quest();
        newQuest.questName = questName;
        newQuest.questDescription = questDescription;
        newQuest.questReward = questReward;
        newQuest.isActive = false;
        newQuest.isComplete = false;
        
        quests.Add(newQuest);
    }
    
    public void UpdateQuest(string questName, bool isActive, bool isComplete)
    {
        Quest quest = quests.Find(x => x.questName == questName);
        quest.isActive = isActive;
        quest.isComplete = isComplete;
    }*/
    
}
