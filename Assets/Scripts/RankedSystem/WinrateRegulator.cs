using System;
using UnityEngine;

public class WinrateRegulator : MonoBehaviour, IRatingObserver
{
    private float _winrate;
    private int _remainGamesWithHighWinrate;

    private Notification _notification;

    private DisplayRemainGamesWithHighWinrate _displayRemainGamesWithHighWinrate;

    public void Init(Notification notification, DisplayRemainGamesWithHighWinrate displayRemainGamesWithHighWinrate)
    {
        _winrate = PlayerPrefs.GetFloat("Winrate", 0.55f);
        _remainGamesWithHighWinrate = PlayerPrefs.GetInt("AmountOfGamesWithHighWinrate", 0);
        
        _notification = notification;
        _displayRemainGamesWithHighWinrate = displayRemainGamesWithHighWinrate;
    }

    public void RegulateWinrate(float winrate, int amountOfGames)
    {
        _winrate = winrate;
        _remainGamesWithHighWinrate = amountOfGames;
        PlayerPrefs.SetInt("AmountOfGamesWithHighWinrate", _remainGamesWithHighWinrate);
        PlayerPrefs.SetFloat("Winrate", _winrate);
        
        _displayRemainGamesWithHighWinrate.DisplayRemainGamesWithHighWinrateCount();
        _notification.ShowMessage($"Вы улучшили свои навыки, теперь ваш винрейт будет повышен до {Mathf.RoundToInt(_winrate * 100)}% на следующие 10 игр.");
    }

    public void OnRatingChanged(int rating)
    {
        if (_remainGamesWithHighWinrate > 0)
        {
            _remainGamesWithHighWinrate -= 1;
            PlayerPrefs.SetInt("AmountOfGamesWithHighWinrate", _remainGamesWithHighWinrate);
        }
        else
        {
            PlayerPrefs.SetFloat("Winrate", 0.55f);
        }
    }
}
