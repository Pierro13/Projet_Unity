using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest : MonoBehaviour
{
    public string questName;
    public List<Objective> objectives = new List<Objective>();
    public string questDescription;
    public int questReward;
    // public bool isActive;
    public bool isComplete;
    
    public void StartQuest()
    {
        // isActive = true;
        Debug.Log("Starting quest: " + questName);
        isComplete = false;
        foreach (Objective objective in objectives)
        {
            objective.ResetObjective();
        }
    }
    
    public void CompleteObjective(string objectiveName)
    {
        Objective objective = objectives.Find(x => x.objectiveName == objectiveName);
        if (objective != null)
        {
            objective.Complete();
            CheckQuestCompletion();
        }
    }

    public void CheckQuestCompletion()
    {
        foreach (Objective objective in objectives)
        {
            if(!objective.isCompleted) return;
        }
        isComplete = true;
        Debug.Log("Quest " + questName + " is complete!");
        // Ajouter la récompense : score ?
    }
}
