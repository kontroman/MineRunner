using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static Text diamondsText;
    public static Text CountBooster1;
    public static Text CountBooster2;
    public static Text CountBooster3;
    public static Text CountBooster4;

    public static int diamonds = 5522;

    public static int currentSkin;

    public static int[] skins = new int[6];

    public static int priceBooster1 = 400;
    public static int priceBooster2 = 500;
    public static int priceBooster3 = 750;
    public static int priceBooster4 = 1500;

    public static int Booster1;
    public static int Booster2;
    public static int Booster3;
    public static int Booster4;

    public static int highScore;

    public static int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            if (value > highScore)
                highScore = value;
        }
    }

    private void Start()
    {
        SaveLoad.Load();
    }

    public static void UpdateTexts()
    {
        for(int i = 0; i < boosters.count; i++)
        {
            boosterTexts[i].text = boosters[i]._boosterCount.ToString();
        }
    }
}
