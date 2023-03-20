using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GoToFactory : MonoBehaviour
{
    [SerializeField] private Button button;

    [SerializeField] private int moneyToEarn;
    [SerializeField] private float hungryConsumption;
    [SerializeField] private float sleepyConsumption;
    [SerializeField] private float moodConsumption;

    private IProgressBarObserver[] _progressBarObservers;
    private StatsValueChanger _statsValueChanger;
    
    public void Init(IProgressBarObserver[] progressBarObservers, StatsValueChanger statsValueChanger)
    {
        _progressBarObservers = progressBarObservers;
        _statsValueChanger = statsValueChanger;

        button.onClick.AddListener(() => _statsValueChanger.DecreaseStats(hungryConsumption, Stats.Hungry));
        button.onClick.AddListener(() => _statsValueChanger.DecreaseStats(moodConsumption, Stats.Mood));
        button.onClick.AddListener(() => _statsValueChanger.DecreaseStats(sleepyConsumption, Stats.Sleepy));
        button.onClick.AddListener(() => Bank.Instance.GetMoney(moneyToEarn));
        
        foreach (var progressBarObserver in _progressBarObservers)
        {
            button.onClick.AddListener(progressBarObserver.OnValueChanged);
        }
    }

    private void OnDisable()
    {
        foreach (var progressBarObserver in _progressBarObservers)
        {
            button.onClick.RemoveListener(progressBarObserver.OnValueChanged);
        }
    }
}
