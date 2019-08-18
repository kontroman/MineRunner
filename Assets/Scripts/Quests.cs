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
    public static int localTarget;
    private static int random;
    static Quest quest;


    void Initializing()
    {
        lastQuestCoins = PlayerPrefs.GetInt("LastCoinsQuest", 0);
        lastQuestScore = PlayerPrefs.GetInt("LastScoreQuest", 0);
        HighScore = GameController.highScore;
    }
    void Start()
    {
        Initializing();
        quest = SelectQuest();
        taskText.text = quest.Discription;
        Destroy(taskText, 8f);
    }

    public static bool CompleteTask()
    {
        return quest.CheckForComplete(GetCurrentTarget());
    }

    static int GetCurrentTarget()
    {
        switch (random)
        {
            case 0:
                localTarget = RunnerController.score;
                break;
            case 1:
                localTarget = RunnerController.diamonds;
                break;
            case 2:
                localTarget = RunnerController.score;
                break;
        }
        return localTarget;
    }

    public Quest SelectQuest()
    {
        random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                return new Quest(HighScore, "Установи новый рекорд");
            case 1:
                return new Quest(lastQuestCoins + 250, "Собери" + (lastQuestCoins + 250) + " алмазов");
            case 2:
                return new Quest(lastQuestScore + 10000, "Получи " + (lastQuestScore + 10000) + " очков");
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