using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DoAction : MonoBehaviour
{
    [SerializeField] private Button button;
    
    [Header("Change stats")]
    [SerializeField] private float hungryConsumptionChange;
    [SerializeField] private float sleepyConsumptionChange;
    [SerializeField] private float moodConsumptionChange;

    [SerializeField] private Actions[] actions;

    private Dictionary<Actions, UnityAction> _actionsMap;
    
    private IProgressBarObserver[] _progressBars;
    private StatsValueChanger _statsValueChanger;

    public void Init(IProgressBarObserver[] progressBars, StatsValueChanger statsValueChanger)
    {
        _progressBars = progressBars;
        _statsValueChanger = statsValueChanger;

        _actionsMap = new Dictionary<Actions, UnityAction>()
        {
            {Actions.DecreaseHungryConsumption, DecreaseHungryConsumption},
            {Actions.DecreaseMoodConsumption, DecreaseMoodConsumption},
            {Actions.DecreaseSleepyConsumption, DecreaseSleepyConsumption},
            {Actions.IncreaseHungryConsumption, IncreaseHungryConsumption},
            {Actions.IncreaseMoodConsumption, IncreaseMoodConsumption},
            {Actions.IncreaseSleepyConsumption, IncreaseSleepyConsumption}
        };

        foreach (var action in actions)
        {
            button.onClick.AddListener(_actionsMap[action]);
        }
        
        OnValueChanged();
    }

    private void OnDisable()
    {
        foreach (var action in actions)
        {
            button.onClick.RemoveListener(_actionsMap[action]);
        }
    }

    private void OnValueChanged()
    {
        foreach (var progressBar in _progressBars)
        {
            progressBar.OnValueChanged();
        }
    }

    private void DecreaseHungryConsumption()
    {
        _statsValueChanger.DecreaseStats(hungryConsumptionChange, Stats.Hungry);
        OnValueChanged();
    }

    private void DecreaseMoodConsumption()
    {
        _statsValueChanger.DecreaseStats(moodConsumptionChange, Stats.Mood);
        OnValueChanged();
    }

    private void DecreaseSleepyConsumption()
    {
        _statsValueChanger.DecreaseStats(sleepyConsumptionChange, Stats.Sleepy);
        OnValueChanged();
    }
    
    private void IncreaseHungryConsumption()
    {
        _statsValueChanger.IncreaseStats(hungryConsumptionChange, Stats.Hungry);
        OnValueChanged();
    }

    private void IncreaseMoodConsumption()
    {
        _statsValueChanger.IncreaseStats(moodConsumptionChange, Stats.Mood);
        OnValueChanged();
    }

    private void IncreaseSleepyConsumption()
    {
        _statsValueChanger.IncreaseStats(sleepyConsumptionChange, Stats.Sleepy);
        OnValueChanged();
    }
}