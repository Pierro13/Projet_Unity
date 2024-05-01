using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective : MonoBehaviour
{
    public string objectiveName;
    public bool isCompleted = false;
    
    public void Complete()
    {
        isCompleted = true;
        Debug.Log("Objective Completed: " + objectiveName);
    }

    // Réinitialise l'état de l'objectif (pour rejouer une quete)
    public void ResetObjective()
    {
        isCompleted = false;
    }
}
