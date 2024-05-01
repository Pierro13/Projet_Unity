using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    
    public void AddQuest(string questName, string questDescription, int questReward)
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
    }

    private void Awake()
    {
        AddQuest("Entraînement de vol", "Apprendre à voler", 100);
    }
}
