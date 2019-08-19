using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour {

    public GameObject MainMenuObject;
    public GameObject BoosterMenu;
    public GameObject SkinsMenu;
    public GameObject Player;

    private void Start()
    {
        SaveLoad.Load();
    }

    private void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void LeftButtonShop()
    {
        ShopController.Shop.MoveSkinLeft();
    }
    public void RightButtonShop()
    {
        ShopController.Shop.MoveSkinRight();
    }
    public  void StartGame()
    {
        SaveLoad.Save();
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        SaveLoad.Save();
        if (BoosterMenu.activeSelf)
        {
            BoosterMenu.SetActive(false);
            MainMenuObject.SetActive(true);
        }
        else
        {
            Player.SetActive(false);
            BoosterMenu.SetActive(true);
            SkinsMenu.SetActive(false);
            GameController.UpdateTexts();
        }
        PlaySound();
    }

    public void OpenShop()
    {
        if (MainMenuObject.activeSelf)
        {
            BoosterMenu.SetActive(true);
            MainMenuObject.SetActive(false);
            GameController.CountBooster1 = GameObject.FindGameObjectWithTag("CBoost1").GetComponent<Text>();
            GameController.CountBooster2 = GameObject.FindGameObjectWithTag("CBoost2").GetComponent<Text>();
            GameController.CountBooster3 = GameObject.FindGameObjectWithTag("CBoost3").GetComponent<Text>();
            GameController.CountBooster4 = GameObject.FindGameObjectWithTag("CBoost4").GetComponent<Text>();
            GameController.diamondsText = GameObject.FindGameObjectWithTag("DiamondText").GetComponent<Text>();
            GameController.UpdateTexts();
        }
        else
        {
            Player.SetActive(true);
            BoosterMenu.SetActive(false);
            SkinsMenu.SetActive(true);
        }
        PlaySound();
    }
    public void BuyBooster1()
    {
        if(GameController.priceBooster1 < GameController.diamonds)
        {
            GameController.diamonds -= GameController.priceBooster1;
            GameController.Booster1++;
        }
        GameController.UpdateTexts();
        PlaySound();
    }
    public void BuyBooster2()
    {
        if (GameController.priceBooster2 < GameController.diamonds)
        {
            GameController.diamonds -= GameController.priceBooster2;
            GameController.Booster2++;
        }
        GameController.UpdateTexts();
        PlaySound();
    }
    public void BuyBooster3()
    {
        if (GameController.priceBooster3 < GameController.diamonds)
        {
            GameController.diamonds -= GameController.priceBooster3;
            GameController.Booster3++;
        }
        GameController.UpdateTexts();
        PlaySound();
    }
    public void BuyBooster4()
    {
        if (GameController.priceBooster4 < GameController.diamonds)
        {
            GameController.diamonds -= GameController.priceBooster4;
            GameController.Booster4++;
        }
        GameController.UpdateTexts();
        PlaySound();
    }

    public void Exit()
    {
        SaveLoad.Save();
        Application.Quit();
    }
}
