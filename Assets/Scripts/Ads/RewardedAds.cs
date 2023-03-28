using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class RewardedAds : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.CloseVideoEvent += Reward;
    }

    private void OnDisable()
    {
        YandexGame.CloseVideoEvent -= Reward;
    }

    private void Reward(int id)
    {
        if (id == 0)
            GetMoney();
        
        if (id == 1)
            Continue();
    }

    private void GetMoney()
    {
        Bank.Instance.GetMoney(1000);
    }

    private void Continue()
    {
        PlayerPrefs.SetFloat("Hungry", 1);
        PlayerPrefs.SetFloat("Mood", 1);
        PlayerPrefs.SetFloat("Sleepy", 1);
        SceneManager.LoadScene("Main");
    }
}
