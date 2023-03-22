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
    private Button[] _buttons;
    private ImproveSkills[] _improveSkills;

    public void Init(WinrateRegulator winrateRegulator, ImproveSkills[] improveSkills)
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(RegulateWinrate);
        
        _winrateRegulator = winrateRegulator;
        _improveSkills = improveSkills;

        _buttons = new Button[_improveSkills.Length];
        
        for (int i = 0; i < _improveSkills.Length; i++)
        {
            _buttons[i] = _improveSkills[i].GetComponent<Button>();
        }
        
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
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
        
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
