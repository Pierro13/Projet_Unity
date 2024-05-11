using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    public TextMeshProUGUI questTitleText;
    public TextMeshProUGUI questDescriptionText;
    public TextMeshProUGUI objectivesText;

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
                objectivesString += " (Echoué)";
            }
            objectivesString += "\n";
        }
        objectivesText.text = objectivesString;
    }
}
