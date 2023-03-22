using System;
using UnityEngine;
using UnityEngine.UI;

public class ImproveSkills : MonoBehaviour, IRatingObserver
{
    [SerializeField] private float improvedWinrate;
    [SerializeField] private int amountOfHighWinrateGames;
    [SerializeField] private int cost;
    
    private Button _button;
    private WinrateRegulator _winrateRegulator;

    public void Init(WinrateRegulator winrateRegulator)
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(RegulateWinrate);
        
        _winrateRegulator = winrateRegulator;
        
        if (PlayerPrefs.GetInt("AmountOfGamesWithHighWinrate") > 0)
        {
            _button.interactable = false;
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RegulateWinrate);
    }

    private void RegulateWinrate()
    {
        _button.interactable = false;
        _winrateRegulator.RegulateWinrate(improvedWinrate, amountOfHighWinrateGames);
        Bank.Instance.SpendMoney(cost);
    }
    
    public void OnRatingChanged(int rating)
    {
        if (PlayerPrefs.GetInt("AmountOfGamesWithHighWinrate") <= 0)
        {
            _button.interactable = true;
        }
    }
}
