using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public static void Save()
    {
        PlayerPrefs.SetInt("AvailableSkin2", GameController.skins[1]);
        PlayerPrefs.SetInt("AvailableSkin3", GameController.skins[2]);
        PlayerPrefs.SetInt("AvailableSkin4", GameController.skins[3]);
        PlayerPrefs.SetInt("AvailableSkin5", GameController.skins[4]);
        PlayerPrefs.SetInt("AvailableSkin6", GameController.skins[5]);
        PlayerPrefs.SetInt("Diamonds", GameController.Diamonds);
        PlayerPrefs.SetInt("HighScore", GameController.HighScore);
        PlayerPrefs.SetInt("CurrentSkin", GameController.currentSkin);
        PlayerPrefs.SetInt("Boosters1", GameController.Booster1);
        PlayerPrefs.SetInt("Boosters2", GameController.Booster2);
        PlayerPrefs.SetInt("Boosters3", GameController.Booster3);
        PlayerPrefs.SetInt("Boosters4", GameController.Booster4);
        PlayerPrefs.SetInt("LastCoinsQuest", Quests.lastQuestCoins);
        PlayerPrefs.SetInt("LastScoreQuest", Quests.lastQuestScore);
    }

    public static void Load()
    {
        GameController.skins[1] = PlayerPrefs.GetInt("AvailableSkin2", 0);
        GameController.skins[2] = PlayerPrefs.GetInt("AvailableSkin3", 0);
        GameController.skins[3] = PlayerPrefs.GetInt("AvailableSkin4", 0);
        GameController.skins[4] = PlayerPrefs.GetInt("AvailableSkin5", 0);
        GameController.skins[5] = PlayerPrefs.GetInt("AvailableSkin6", 0);
        GameController.Diamonds = PlayerPrefs.GetInt("Diamonds", 8124);
        GameController.HighScore = PlayerPrefs.GetInt("HighScore", 0);
        GameController.currentSkin = PlayerPrefs.GetInt("CurrentSkin", 0);
        GameController.Booster1 = PlayerPrefs.GetInt("Boosters1", 0);
        GameController.Booster2 = PlayerPrefs.GetInt("Boosters2", 0);
        GameController.Booster3 = PlayerPrefs.GetInt("Boosters3", 0);
        GameController.Booster4 = PlayerPrefs.GetInt("Boosters4", 0);
    }
}
