using System;
using UnityEngine;

public class WinrateRegulator : MonoBehaviour, IRatingObserver
{
    private float _winrate;
    private int _remainGamesWithHighWinrate;

    private void OnEnable()
    {
        _winrate = PlayerPrefs.GetFloat("Winrate", 0.55f);
        _remainGamesWithHighWinrate = PlayerPrefs.GetInt("AmountOfGamesWithHighWinrate", 0);
    }

    public void RegulateWinrate(float winrate, int amountOfGames)
    {
        _winrate = winrate;
        _remainGamesWithHighWinrate = amountOfGames;
        PlayerPrefs.SetInt("AmountOfGamesWithHighWinrate", _remainGamesWithHighWinrate);
        PlayerPrefs.SetFloat("Winrate", _winrate);
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
            RegulateWinrate(0.55f, 0);
        }
        
        Debug.Log(_remainGamesWithHighWinrate);
        Debug.Log(_winrate);
    }
}
