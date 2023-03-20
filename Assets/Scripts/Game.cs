using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private RatingDisplayer ratingDisplayer;
    [SerializeField] private Alert alert;
    [SerializeField] private StatsValueChanger statsValueChanger;
    [SerializeField] private GameOver gameOver;
    
    [Header("Actions")]
    [SerializeField] private PlayGame playGame;
    [SerializeField] private GoToFactory goToFactory;
    [SerializeField] private GoToMcWithFirends goToMcWithFirends;
    
    [Header("Progress Bars")] 
    [SerializeField] private GameObject[] progressBarGameObjects;
    private IProgressBarObserver[] _progressBars;
    
    private void OnEnable()
    {
        _progressBars = new IProgressBarObserver[progressBarGameObjects.Length];
        
        for (int i = 0; i < _progressBars.Length; i++)
        {
            _progressBars[i] = progressBarGameObjects[i].GetComponent<IProgressBarObserver>();
        }

        gameOver.Init(alert, statsValueChanger); 
        playGame.Init(_progressBars, ratingDisplayer, statsValueChanger);
        goToFactory.Init(_progressBars, statsValueChanger);
        goToMcWithFirends.Init(_progressBars, statsValueChanger);
    }
}
