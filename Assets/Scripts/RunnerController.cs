using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour
{
    public Text BoosterText1;
    public Text BoosterText2;
    public Text BoosterText3;
    public Text BoosterText4;
    public  Text DiamondText;
    public  Text scoreText;
    public static int score;
    private bool doubleScore = false;
    public static bool doubleDiamon = false;
    public GameObject pauseMenu;
    public GameObject deathMenu;

    public static Vector3[] coordiantesHP = new Vector3[6];
    public static Vector3[] coordiantesArmor = new Vector3[6];
    private static GameObject prefabHP;
    private static GameObject prefabArmor;
    private static GameObject hpPref;
    private static GameObject ArmorPref;
    private static bool paused = false;

    private  GameObject bos1;
    private  GameObject bos2;
    private  GameObject bos3;
    private  GameObject bos4;
    private  GameObject PauseButtonInCanvas;
    private  GameObject DiamondImage;

    public  Text BestScoreText;
    public  Text ScoreText;

    private GameObject ClickSound;

    private int PlusScore = 1;

    public static int diamonds;

    public static void DrawHP(int hp)  //рисуем сердечки
    {
        for(int i=0; i<hp; i++)
        {
            hpPref = Instantiate(prefabHP, coordiantesHP[i], Quaternion.identity);
            hpPref.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
        for(int i=hp; i<6; i++)
        {
            hpPref = Instantiate(prefabHP, coordiantesHP[i], Quaternion.identity);
            hpPref.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            hpPref.GetComponent<Image>().color = new Color32(63, 63, 63, 255);
        }
    }

    public static void DrawArmor(int armor) //рисуем броню
    {
        if(PlayerController1.armor >= 0)
        {
            for (int i = 0; i < armor; i++)
            {
                ArmorPref = Instantiate(prefabArmor, coordiantesArmor[i], Quaternion.identity);
                ArmorPref.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            }
            for (int i = armor; i < 6; i++)
            {
                ArmorPref = Instantiate(prefabArmor, coordiantesArmor[i], Quaternion.identity);
                ArmorPref.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                ArmorPref.GetComponent<Image>().color = new Color32(63, 63, 63, 255);
            }
        }
    }


    private void Start()
    {
        ClickSound = GameObject.FindGameObjectWithTag("ClickSound");
        deathMenu.SetActive(false);
        PlusScore = 1;
        Time.timeScale = 1;
        score = 0;
        diamonds = 0;

        DiamondImage = GameObject.FindGameObjectWithTag("DiamondImage");
        PauseButtonInCanvas = GameObject.FindGameObjectWithTag("PauseButton");

        bos1 = GameObject.FindGameObjectWithTag("CBoost1");
        bos2 = GameObject.FindGameObjectWithTag("CBoost2");
        bos3 = GameObject.FindGameObjectWithTag("CBoost3");
        bos4 = GameObject.FindGameObjectWithTag("CBoost4");

        coordiantesArmor[0] = new Vector3(-85f, -535f, 0);
        coordiantesArmor[1] = new Vector3(-50f, -535f, 0);
        coordiantesArmor[2] = new Vector3(-15f, -535f, 0);
        coordiantesArmor[3] = new Vector3(20f, -535f, 0);
        coordiantesArmor[4] = new Vector3(55f, -535f, 0);
        coordiantesArmor[5] = new Vector3(90f, -535f, 0);

        coordiantesHP[0] = new Vector3(-85f, -580f, 0);
        coordiantesHP[1] = new Vector3(-50f, -580f, 0);
        coordiantesHP[2] = new Vector3(-15f, -580f, 0);
        coordiantesHP[3] = new Vector3(20f, -580f, 0);
        coordiantesHP[4] = new Vector3(55f, -580f, 0);
        coordiantesHP[5] = new Vector3(90f, -580f, 0);

        prefabArmor = GameObject.FindGameObjectWithTag("ArmorObject");
        prefabHP = GameObject.FindGameObjectWithTag("hpObject");
        DrawArmor(0);
        DrawHP(6);
        UpdateTextBoosters();
    }

    void UpdateTextBoosters()  //количество бустеров на кнопках
    {
        if (GameController.Booster1 == 0)
            BoosterText1.text = "";
        else
            BoosterText1.text = "" + GameController.Booster1;

        if (GameController.Booster2 == 0)
            BoosterText2.text = "";
        else
            BoosterText2.text = "" + GameController.Booster2;

        if (GameController.Booster3 == 0)
            BoosterText3.text = "";
        else
            BoosterText3.text = "" + GameController.Booster3;

        if (GameController.Booster4 == 0)
            BoosterText4.text = "";
        else
            BoosterText4.text = "" + GameController.Booster4;
    }

    void Drink()
    {
        GameObject.FindGameObjectWithTag("Drink").GetComponent<AudioSource>().Play();
    } //звук питья

    void NoDrink()
    {
        GameObject.FindGameObjectWithTag("NoDrink").GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        DiamondText.text = "" + diamonds;

        if(paused == false)
        {
            if (doubleScore)
            {
                score += PlusScore * 3;
            }

            else
            {
                score += PlusScore;
            }
            scoreText.text = "" + score;
        }

        if (PlayerController1.hp <= 0)
        {
            DrawArmor(0);
            DrawHP(0);
            Death();
            PlayerController1.hp++;
        }
    }

    public void UseBooster1()
    {
        HiderBoosters.timeLastUseBooster = 15;
        if (GameController.Booster1 > 0 && PlayerController1.armor < 6)
        {
            PlayerController1.armor += 2;
            DrawArmor(PlayerController1.armor);
            GameController.Booster1 -= 1;
            UpdateTextBoosters();
            Drink();
        }else
        NoDrink();
    }

    public void UseBooster2()
    {
        HiderBoosters.timeLastUseBooster = 15;
        if(GameController.Booster2 > 0)
        {
            doubleDiamon = true;
            StartCoroutine(deactiveteDoubleDiamonds());
            GameController.Booster2 -= 1;
            UpdateTextBoosters();
            Drink();
        }else
        NoDrink();
    }

    IEnumerator deactiveteDoubleDiamonds()
    {
        yield return new WaitForSeconds(30);
        doubleDiamon = false;
    }

    public void UseBooster3()
    {
        HiderBoosters.timeLastUseBooster = 15;
        if (GameController.Booster3 > 0)
        {
            doubleScore = true;
            StartCoroutine(deactiveteDoubleScore());
            GameController.Booster3 -= 1;
            UpdateTextBoosters();
            Drink();
        }else
        NoDrink();
    }

    IEnumerator deactiveteDoubleScore()
    {
        yield return new WaitForSeconds(30);
        doubleScore = false;
    }

    public void UseBooster4()
    {
        HiderBoosters.timeLastUseBooster = 15;
        if (GameController.Booster4 > 0 && PlayerController1.speed > 1)
        {
            GameController.Booster4 -= 1;
            Drink();
            PlayerController1.speed -= 0.2f;
            UpdateTextBoosters();
        }else
        NoDrink();
    }

    public void PauseButton() //хуя длинная функция
    {
        ClickSound.GetComponent<AudioSource>().Play();
        if (paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            paused = false;
            ActiveteBoosters();
            PauseButtonInCanvas.SetActive(true);
            DiamondImage.SetActive(true);
            scoreText.enabled = true;
            DiamondText.enabled = true;
        }
        else
        {
            PauseButtonInCanvas.SetActive(false);
            DiamondImage.SetActive(false);
            scoreText.enabled = false;
            DiamondText.enabled = false;
            DeactiveteBoosters();
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
    }
     
    public void MainMenuButton()
    {
        ClickSound.GetComponent<AudioSource>().Play();
        SaveLoad.Save();
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene(0);
    }

    void Death()
    {
        GameController.diamonds += diamonds;
        PlusScore = 0;
        deathMenu.SetActive(true);

        ScoreText = GameObject.FindGameObjectWithTag("YourScore").GetComponent<Text>();
        BestScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();

        GameController.HighScore = score;

        BestScoreText.text = "" + GameController.HighScore;
        ScoreText.text = "" + score;
        DeactiveteBoosters();
        PauseButtonInCanvas.SetActive(false);
        DiamondImage.SetActive(false);
        scoreText.enabled = false;
        DiamondText.enabled = false;

        CamShaker._camera = null; // что бы камера не тряслась после смерти, хз почему трясется при timeScale = 0

        Time.timeScale = 0;
        SaveLoad.Save();
        Quests.CompleteTask();
        Quests.UpdateQuestsTarget();
    }

    public void Restart()
    {
        ClickSound.GetComponent<AudioSource>().Play();
        SaveLoad.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DeactiveteBoosters()
    {
        bos1.SetActive(false);
        bos2.SetActive(false);
        bos3.SetActive(false);
        bos4.SetActive(false);
    }

    private void ActiveteBoosters()
    {
        bos1.SetActive(true);
        bos2.SetActive(true);
        bos3.SetActive(true);
        bos4.SetActive(true);
    }
}
