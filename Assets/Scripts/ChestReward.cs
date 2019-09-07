using UnityEngine;

public class ChestReward : MonoBehaviour
{
    public void SelectReward()
    {
        int random = Random.Range(0, 101);
        #region ifes
        if (random <= 2)
            RewardSkin();
        else if (random < 57)
            RewardDiamonds(250);
        else if (random < 67)
            RewardDiamonds(500);
        else if (random < 75)
            RewardDiamonds(1000);
        else
            SelectBoosters();
        #endregion
    }
    void SelectBoosters()
    {
        int random = Random.Range(1, 5);
        switch (random)
        {
            case 1:
                RewardBoosters(1);
                break;
            case 2:
                RewardBoosters(2);
                break;
            case 3:
                RewardBoosters(3);
                break;
            case 4:
                RewardBoosters(4);
                break; 
        }
    }

    void RewardBoosters(int numberOfBooster)
    {
        switch (numberOfBooster)
        {
            case 1:
                GameController.Booster1 += 2;
                break;
            case 2:
                GameController.Booster2 += 2;
                break;
            case 3:
                GameController.Booster3 += 2;
                break;
            case 4:
                GameController.Booster4 += 2;
                break;
        }
    }
    void RewardDiamonds(int amount)
    {
        GameController.diamonds += amount;
    }
    void RewardSkin()
    {
        if(GameController.skins[5] != 1)
            GameController.skins[5] = 1;
        else
            RewardDiamonds(2500);
    }

}
