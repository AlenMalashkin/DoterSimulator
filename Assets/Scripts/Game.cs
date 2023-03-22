using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StatsValueChanger statsValueChanger;
    [SerializeField] private Alert alert;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private WinrateRegulator winrateRegulator;
    
    [Header("Actions")] 
    [SerializeField] private DoAction[] actions;
    [SerializeField] private PlayGame playGame;
    [SerializeField] private ImproveSkills improveSkills;
    
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

        gameOver.Init(alert, statsValueChanger);
        improveSkills.Init(winrateRegulator);
        playGame.Init(_ratingObservers);
    }
}
