using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questTitleText;
    [SerializeField] private TextMeshProUGUI questDescriptionText;
    [SerializeField] private TextMeshProUGUI objectivesText;
    [SerializeField] private TextMeshProUGUI questRecapText;
    
    private List<string> recapList = new List<string>();
    public void UpdateQuestPanel(Quest quest)
    {
        // Mettre à jour le panneau avec les informations de la quête spécifiée
        questTitleText.text = quest.questName;
        questDescriptionText.text = quest.questDescription;

        // Construire le texte des objectifs
        string objectivesString = "";
        foreach (Objective objective in quest.objectives)
        {
            objectivesString += "- " + objective.objectiveName;
            if (objective.isCompleted)
            {
                objectivesString += " (Complété)";
            } else if (objective.isFailed)
            {
                objectivesString += " (Échoué)";
            } else
            {
                objectivesString += " (Non complété)";
            }
            objectivesString += "\n";
        }
        objectivesText.text = objectivesString;
    }

    public void AddRecap()
    {
        QuestManager questManager = QuestManager.instance;
        if(questManager != null)
        {
            List<Quest> quests = questManager.GetQuestList();
            foreach (Quest quest in quests)
            {
                string result = quest.isComplete ? "Succès" : "Échec";
                recapList.Add(quest.questName + " - " + result);
            }
        }
        /*string result = quest.isComplete ? "Succès" : "Échec";
        recapList.Add(quest.questName + " - " + result);*/
    }

    public void ShowQuestsRecap()
    {
        AddRecap();
        string recapString = "";
        foreach (string recap in recapList)
        {
            recapString += recap + "\n";
        }
        questRecapText.text = recapString;
        gameObject.SetActive(true);
        AudioSource planeEngineAudio = GameObject.Find("PlaneEngineAudio").GetComponent<AudioSource>();
        planeEngineAudio.Stop();
    }
}
