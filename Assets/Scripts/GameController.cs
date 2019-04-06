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

    public static int Diamonds = 5522;

    public static int currentSkin;

    public static int[] skins = new int[6];

    public static int priceBooster1 = 350;
    public static int priceBooster2 = 75;
    public static int priceBooster3 = 100;
    public static int priceBooster4 = 500;

    public static int Booster1;
    public static int Booster2;
    public static int Booster3;
    public static int Booster4;

    public static int HighScore;

    private void Start()
    {
        SaveLoad.Load();
    }

    public static void UpdateTexts()
    {
        if(Booster1 > 0)
            CountBooster1.text = "" + Booster1;
        else
            CountBooster1.text = "";

        if (Booster2 > 0)
            CountBooster2.text = "" + Booster2;
        else
            CountBooster2.text = "";

        if (Booster3 > 0)
            CountBooster3.text = "" + Booster3;
        else
            CountBooster3.text = "";

        if (Booster4 > 0)
            CountBooster4.text = "" + Booster4;
        else
            CountBooster4.text = "";
        diamondsText.text = "" + Diamonds;
    }
}
