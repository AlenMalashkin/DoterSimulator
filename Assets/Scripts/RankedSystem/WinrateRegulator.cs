using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinrateRegulator
{
    private float _winrate = PlayerPrefs.GetFloat("Winrate", 0.55f);
    private int _remainGamesWithHighWinrate = PlayerPrefs.GetInt("AmountOfGamesWithHighWinrate", 0);
    
    public void RegulateWinrate(float winrate, int amountOfGames)
    {
        _winrate = winrate;
        _remainGamesWithHighWinrate = amountOfGames;
        PlayerPrefs.SetInt("AmountOfGamesWithHighWinrate", _remainGamesWithHighWinrate);
        PlayerPrefs.SetFloat("Winrate", _winrate);
    }

    public void CheckRemainGamesWithHighWinrate()
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
