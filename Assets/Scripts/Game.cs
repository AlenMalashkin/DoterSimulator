using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private RatingDisplayer ratingDisplayer;
    [SerializeField] private Alert alert;
    [SerializeField] private StatsValueChanger statsValueChanger;
    [SerializeField] private GameOver gameOver;

    [Header("Actions")] 
    [SerializeField] private DoAction[] actions;
    [SerializeField] private PlayGame playGame;
    
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

        foreach (var action in actions)
        {
            action.Init(_progressBars, statsValueChanger);
        }

        gameOver.Init(alert, statsValueChanger);

        playGame.Init(ratingDisplayer);
    }
}
