using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StatsValueChanger statsValueChanger;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private WinrateRegulator winrateRegulator;
    [SerializeField] private DisplayRemainGamesWithHighWinrate displayRemainGamesWithHighWinrate;
    
    [Header("Notifications")]
    [SerializeField] private Notification alert;
    [SerializeField] private Notification notification;
    
    [Header("Actions")] 
    [SerializeField] private DoAction[] actions;
    [SerializeField] private ImproveSkills[] improveActions;
    [SerializeField] private PlayGame playGame;
    
    [Header("Progress Bar Observers")] 
    [SerializeField] private GameObject[] progressBarGameObjects;
    private IProgressBarObserver[] _progressBars;

    [Header("Raring Observers")] 
    [SerializeField] private GameObject[] ratingObserverGameObjects;
    private IRatingObserver[] _ratingObservers;

    private void OnEnable()
    {
        _progressBars = new IProgressBarObserver[progressBarGameObjects.Length];
        _ratingObservers = new IRatingObserver[ratingObserverGameObjects.Length];
        
        for (int i = 0; i < _progressBars.Length; i++)
        {
            _progressBars[i] = progressBarGameObjects[i].GetComponent<IProgressBarObserver>();
        }

        for (int i = 0; i < ratingObserverGameObjects.Length; i++)
        {
            _ratingObservers[i] = ratingObserverGameObjects[i].GetComponent<IRatingObserver>();
        }

        foreach (var action in actions)
        {
            action.Init(_progressBars, statsValueChanger);
        }

        foreach (var action in improveActions)
        { 
            action.Init(winrateRegulator, improveActions);
        }

        winrateRegulator.Init(notification, displayRemainGamesWithHighWinrate);
        gameOver.Init(alert, statsValueChanger);
        playGame.Init(_ratingObservers);
    }
}
