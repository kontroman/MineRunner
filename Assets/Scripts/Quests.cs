using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public Text taskText;
    private int lastQuestCoins;
    private int lastQuestScore;
    private int HighScore;
    Quest quest;

    void Start()
    {
        quest = SelectQuest();
        taskText.text = quest.Discription;
    }

    void Update()
    {
        if (quest.CheckForComplete(1))
        {

        }
    }

    public Quest SelectQuest()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                return new Quest("Set new record to reward");
            case 1:
                return new Quest(1000, "Collect 1000 coins to reward");
            case 2:
                return new Quest(5000, "Get 5000 score to reward");
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

    public Quest(string discription)
    {
        Discription = discription;
    }

    public bool CheckForComplete(int target)
    {
        if (Target >= target)
            isDone = true;
        return isDone;
    }
}