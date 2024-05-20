using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    [SerializeField] private List<Quest> quests = new List<Quest>();
    private int _currentQuestIndex;
    [SerializeField] private QuestPanel questPanel;
    private bool recapVisible = false;
    
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

    private void Start()
    {
        StartFirstQuest();    
    }

    public void setCurrentQuestIndex(int index)
    {
        quests[_currentQuestIndex].gameObject.SetActive(false);
        _currentQuestIndex = index;
        quests[_currentQuestIndex].gameObject.SetActive(true);
    }
    
    private void Update()
    {
        Quest currentQuest = quests[_currentQuestIndex];
        if (currentQuest.isComplete || currentQuest.isFailed)
        {
            if (_currentQuestIndex < quests.Count - 1)
            {
                _currentQuestIndex++;
                Quest nextQuest = quests[_currentQuestIndex];
                currentQuest.gameObject.SetActive(false);
                nextQuest.gameObject.SetActive(true);
                nextQuest.StartQuest();
            } else if(!recapVisible)
            {
                currentQuest.gameObject.SetActive(false);
                questPanel.ShowQuestsRecap();
                recapVisible = true;
            }
        }
        
        if(recapVisible)
        {
            Time.timeScale = 0.0f; // Pause the game
        }
    }

    private void StartFirstQuest()
    {
        if (quests.Count > 0)
        {
            _currentQuestIndex = 0;
            Quest firstQuest = quests[_currentQuestIndex];
            if (firstQuest != null)
            {
               firstQuest.StartQuest();
               Quest currentQuest = quests[_currentQuestIndex];
               currentQuest.gameObject.SetActive(true);
            }
        }
    }
    
    public void StartQuest(string questName)
    {
        Quest quest = GetQuest(questName);
        if (quest != null)
        {
            quest.StartQuest();
        }
        else
        {
            Debug.LogWarning("Quest " + questName + " not found");
        }
    }
    
    public List<Quest> GetQuestList()
    {
        return quests;
    }
    public Quest GetQuest(string questName)
    {
        return quests.Find(x => x.questName == questName);
    }
    
    public void CompleteObjective(string questName, string objectiveName)
    {
        Quest quest = GetQuest(questName);
        if (quest != null)
        {
            quest.CompleteObjective(objectiveName);
        }
        else
        {
            Debug.LogWarning("Quest " + questName + " not found");
        }
    }
    
    public void FailObjective(string questName, string objectiveName)
    {
        Quest quest = GetQuest(questName);
        if (quest != null)
        {
            quest.FailObjective(objectiveName);
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
