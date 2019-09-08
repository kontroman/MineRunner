using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenChest : MonoBehaviour
{
    public GameObject chest;
    public Text openText;
    public static Text rewardText;

    public Swipe swipeControls;
    public ChestReward _chestReward;

    private void Update()
    {
        if (swipeControls.Tap)
        {
            PlayAnimation();
            _chestReward.SelectReward();
        }
    }

    private void PlayAnimation()
    {
        openText.enabled = false;
        chest.GetComponent<Animator>().enabled = true;
    }

    void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void RewardDiamonds(int count)
    {
        rewardText.text = "" + count;
    }
}
