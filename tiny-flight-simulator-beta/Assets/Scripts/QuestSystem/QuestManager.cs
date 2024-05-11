using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    [SerializeField] private List<Quest> quests = new List<Quest>();
    private int _currentQuestIndex;
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

    private void Update()
    {
        Quest currentQuest = quests[_currentQuestIndex];
        if (currentQuest.isComplete)
        {
            if (_currentQuestIndex < quests.Count - 1)
            {
                _currentQuestIndex++;
                Quest nextQuest = quests[_currentQuestIndex];
                currentQuest.gameObject.SetActive(false);
                nextQuest.gameObject.SetActive(true);
                nextQuest.StartQuest();
            }
        }

        if (currentQuest.isFailed)
        {
            if (_currentQuestIndex > 0)
            {
                // Passer à la quête précédente
                _currentQuestIndex--;
                Quest prevQuest = quests[_currentQuestIndex];

                // Désactiver la quête actuelle et activer la précédente
                currentQuest.isFailed = false;
                currentQuest.gameObject.SetActive(false);
                prevQuest.gameObject.SetActive(true);

                // Démarrer la quête précédente
                prevQuest.StartQuest();
                //QuestPanel questPanel = FindObjectOfType<QuestPanel>();
                // if (questPanel != null)
                // {
                //     questPanel.UpdateQuestPanel(prevQuest);
                // }
            }
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
    
    public Quest GetQuest(string questName)
    {
        return quests.Find(x => x.questName == questName);
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
    
    public void failObjective(string questName, string objectiveName)
    {
        Quest quest = quests.Find(x => x.questName == questName);
        if (quest != null)
        {
            quest.failObjective(objectiveName);
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
