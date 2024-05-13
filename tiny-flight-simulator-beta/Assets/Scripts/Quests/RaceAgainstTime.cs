using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceAgainstTime : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints;
    [SerializeField] private QuestPanel questPanel;
    [SerializeField] private DirectionalArrow directionalArrow;
    private Quest _quest;
    [SerializeField] private TextMeshProUGUI countdownText;
    
    [SerializeField] private float countdownTime = 6f;
    private bool isCountdown = false;
    [SerializeField] private Timer timer;
    private bool questLose = false;
    private bool firstStart = false;
    
    private void OnEnable()
    {
        
        // if (directionalArrow != null)
        // {
        //     directionalArrow.SetCheckpoints(checkpoints);
        //     directionalArrow.gameObject.SetActive(true);
        // }
        questLose = false;
        countdownText.gameObject.SetActive(true);
        StartCoroutine(StartCountdown());
        
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
    
    private IEnumerator StartCountdown()
    {
        isCountdown = true;
        float currentTime = countdownTime;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            updateTimer(currentTime);
            yield return null;
            isCountdown = false;
        }
        
        countdownText.gameObject.SetActive(false);
        
        if (directionalArrow != null && !isCountdown)
        {
            directionalArrow.SetCheckpoints(checkpoints);
            directionalArrow.gameObject.SetActive(true);
        }
        
        //Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.StartTimer();
            firstStart = true;
        }
    }

    private void updateTimer(float timeLeft)
    {
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        countdownText.text = seconds.ToString();
    }
    
    private void Update()
    {
        QuestManager questManager = QuestManager.instance;
        bool checkpointsReached = DirectionalArrow.isComplete;
        //Timer timer = FindObjectOfType<Timer>();
        //
        if (questManager != null)
        {
            if (checkpointsReached && timer.isTimerRunning)
            {
                questManager.CompleteObjective("Course contre la montre", "Finir la course");
                timer.disableTimer();
                questPanel.UpdateQuestPanel(_quest);
            }
            else if (!timer.isTimerRunning && !checkpointsReached && firstStart)
            {
                questManager.FailObjective("Course contre la montre", "Finir la course");
                timer.disableTimer();
                questPanel.UpdateQuestPanel(_quest);
                /*questManager.StartQuest("Quête de transition");
                timer.disableTimer();
                Quest transitionQuest = questManager.GetQuest("Quête de transition");
                questPanel.UpdateQuestPanel(transitionQuest);
                questManager.setCurrentQuestIndex(0);
                questLose = true;*/
            }
        }
    }
}
