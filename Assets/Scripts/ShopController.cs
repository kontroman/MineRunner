using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

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
        SaveLoad.Load();
        YourDiamond.text = "" + GameController.diamonds;
        //BuyText = GameObject.FindGameObjectWithTag("BuyText").GetComponent<Text>();
        //PriceText = GameObject.FindGameObjectWithTag("Price").GetComponent<Text>();
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
        {
            BuyText.text = "Купить скин";
        }
        else if (WhichSkinNow == GameController.currentSkin)
        {
            BuyText.text = "Текущий скин";
        }
        else
        {
            BuyText.text = "Выбрать скин";
        }
        UpdatePrice(WhichSkinNow);
    }

    void UpdatePrice(int skin)
    {
        if (GameController.skins[skin] == 0)
        {
            PriceText.text = "" + prices[skin];
        }
        else
        {
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
        gameObject.GetComponent<AudioSource>().Play();
        if (GameController.skins[WhichSkinNow] == 0)
        {
            GameController.diamonds -= prices[WhichSkinNow];
            GameController.skins[WhichSkinNow] = 1;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<AudioSource>().Play();
        }
        else
        {
            GameController.currentSkin = WhichSkinNow;
        }
        UpdatePrice(WhichSkinNow);
        CheckTextButton();
    }
}
