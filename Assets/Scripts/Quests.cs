using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public Text taskText;
    public static int lastQuestCoins;
    public static int lastQuestScore;
    public int HighScore;
    public int localTarget;
    private int random;
    Quest quest;


    void Initializing()
    {
        lastQuestCoins = PlayerPrefs.GetInt("LastCoinsQuest", 0);
        lastQuestScore = PlayerPrefs.GetInt("LastScoreQuest", 0);
        HighScore = GameController.HighScore;
    }
    void Start()
    {
        Initializing();
        quest = SelectQuest();
        taskText.text = quest.Discription;
    }

    public bool CompleteTask()
    {
        Debug.Log(quest.Target);
        return quest.CheckForComplete(getCurrentTarget());
    }

    int getCurrentTarget()
    {
        switch (random)
        {
            case 0:
                localTarget = GameController.HighScore;
                break;
            case 1:
                localTarget = GameController.Diamonds;
                break;
            case 2:
                localTarget = RunnerController.score;
                break;
        }
        Debug.Log(localTarget);
        return localTarget;
    }

    public Quest SelectQuest()
    {
        random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                return new Quest(HighScore, "Set new record to reward");
            case 1:
                return new Quest(lastQuestCoins + 250, "Collect " + (lastQuestCoins + 250) + " coins to reward");
            case 2:
                return new Quest(lastQuestScore + 5000, "Get " + (lastQuestScore + 5000) + " score to reward");
            default:
                return null;
        }
    }
}

public class Quest
{
    public string Discription;
    public bool isDone = false;
    public int Target;

    public Quest(int target, string discription)
    {
        Target = target;
        Discription = discription;
    }
    public bool CheckForComplete(int target)
    {
        if (Target <= target)
            isDone = true;
        return isDone;
    }
}