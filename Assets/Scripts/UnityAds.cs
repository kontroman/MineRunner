using UnityEngine.Advertisements;
using UnityEngine;

public class UnityAds : MonoBehaviour
{
    readonly string gameId = "1629736";

    private void Start()
    {
        Advertisement.Initialize(gameId);
    }

    [System.Obsolete]
    public void ShowRewardedAds()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show("DoubleDiamonds", options);
    }

    void HandleShowResult(ShowResult result)
    {
        if(result == ShowResult.Finished)
        {
            GameController.diamonds += RunnerController.diamonds;
            SaveLoad.Save();
        }
        else if(result == ShowResult.Failed)
        {
            Debug.Log("Ads failed");
        }
        else if(result == ShowResult.Skipped)
        {
            Debug.Log("Ads skipped");
        }
    }

    public void ShowDefaultAds()
    {
        Advertisement.Show("video");
    }
}   
