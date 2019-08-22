using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private AudioSource auS;
    public Swipe swipeControls;
    public static ShopController Shop;
    public GameObject Player;
    public Text PriceText;
    public Text BuyText;
    public Text YourDiamond;
    public Material[] mat = new Material[6];
    private int WhichSkinNow = 0;
    public int[] prices = new int[6];

    void Awake()
    {
        Shop = this;
        GameController.skins[0] = 1;
    }

    private void Update()
    {
        if (swipeControls.SwipeLeft)
            MoveSkinRight();
        if (swipeControls.SwipeRight)
            MoveSkinLeft();

        UpdatePrice(WhichSkinNow);
        CheckTextButton();
    }

    public void Start()
    {
        auS = gameObject.GetComponent<AudioSource>();
        SaveLoad.Load();
        YourDiamond.text = "" + GameController.diamonds;
        Player.SetActive(true);
        WhichSkinNow = GameController.currentSkin;
        Player.GetComponent<Renderer>().material = mat[WhichSkinNow];
    }

    public void MoveSkinLeft() //Уменьшаем материал скина - был 4, стал 3
    {
        if (WhichSkinNow > 0)
        {
            WhichSkinNow--;
            CheckTextButton();
            Player.GetComponent<Renderer>().material = mat[WhichSkinNow];
        }
    }

    public void MoveSkinRight()  //увеличиваем материал скина - был 4, стал 5
    {
        if (WhichSkinNow < 5)
        {
            WhichSkinNow++;
            CheckTextButton();
            Player.GetComponent<Renderer>().material = mat[WhichSkinNow];
        }
    }

    void CheckTextButton()
    {
        YourDiamond.text = "" + GameController.diamonds;
        if (GameController.skins[WhichSkinNow] == 0)
            setBuyText();
        else if (WhichSkinNow == GameController.currentSkin)
            setCurrentText();
        else
            setSelectText();
        if(WhichSkinNow == 5 && GameController.skins[5] == 0)
        {
            BuyText.text = "Недоступно";
        }
        UpdatePrice(WhichSkinNow);
    }

    void setCurrentText()
    {
        BuyText.text = "Текущий скин";
    }

    void setBuyText()
    {
        BuyText.text = "Купить скин";
    }
    void setSelectText()
    {
        BuyText.text = "Выбрать скин";
    }


    void UpdatePrice(int skin)
    {
        if (GameController.skins[skin] == 0)
            PriceText.text = "" + prices[skin];
        else
            PriceText.text = "";
        if(skin == 5)
        {   
            if(GameController.skins[5] == 0)
                PriceText.text = "Награда из сундука";
            else
                PriceText.text = "";
        }
    }

    public void CheckForBuyAvailable()
    {
        if(GameController.diamonds > prices[WhichSkinNow] || GameController.skins[WhichSkinNow] == 1)
        {
            BuySkin();
        }
    }

    public void BuySkin()
    {
        PlaySound();
        if (GameController.skins[WhichSkinNow] == 0 && WhichSkinNow != 5)
        {
            IncreaseDiamonds(prices[WhichSkinNow]);
            GameController.skins[WhichSkinNow] = 1;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<AudioSource>().Play();
        }
        else
        {
            SetCurrentSkin(WhichSkinNow);
        }
        if (WhichSkinNow == 5 && GameController.skins[WhichSkinNow] == 1)
        {
            SetCurrentSkin(WhichSkinNow);
        }
        else
        {
            return;
        }

        UpdatePrice(WhichSkinNow);
        CheckTextButton();
    }

    void SetCurrentSkin(int _skin)
    {
        GameController.currentSkin = _skin;
    }

    void IncreaseDiamonds(int _diamonds)
    {
        GameController.diamonds -= _diamonds;
    }

    void PlaySound()
    {
        auS.Play();
    }
}
