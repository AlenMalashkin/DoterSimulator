using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DoAction : MonoBehaviour
{
    [SerializeField] private Button button;
    
    [Header("Decrease stats")]
    [SerializeField] private float hungryDecreaseConsumption;
    [SerializeField] private float sleepyDecreaseConsumption;
    [SerializeField] private float moodDecreaseConsumption;
    
    [Header("Increase stats")]
    [SerializeField] private float hungryIncreaseConsumption;
    [SerializeField] private float sleepyIncreaseConsumption;
    [SerializeField] private float moodIncreaseConsumption;
    
    private RatingDisplayer _ratingDisplayer;
    private IProgressBarObserver[] _progressBars;
    private StatsValueChanger _statsValueChanger;

    public void Init(IProgressBarObserver[] progressBars, StatsValueChanger statsValueChanger)
    {
        _progressBars = progressBars;
        _statsValueChanger = statsValueChanger;
        
        OnValueChanged();
    }

    private void OnValueChanged()
    {
        foreach (var progressBar in _progressBars)
        {
            progressBar.OnValueChanged();
        }
    }

    public void DecreaseHungryConsumption()
    {
        _statsValueChanger.DecreaseStats(hungryDecreaseConsumption, Stats.Hungry);
        OnValueChanged();
    }

    public void DecreaseMoodConsumption()
    {
        _statsValueChanger.DecreaseStats(moodDecreaseConsumption, Stats.Mood);
        OnValueChanged();
    }

    public void DecreaseSleepyConsumption()
    {
        _statsValueChanger.DecreaseStats(sleepyDecreaseConsumption, Stats.Sleepy);
        OnValueChanged();
    }
    
    public void IncreaseHungryConsumption()
    {
        _statsValueChanger.IncreaseStats(hungryIncreaseConsumption, Stats.Hungry);
        OnValueChanged();
    }

    public void IncreaseMoodConsumption()
    {
        _statsValueChanger.IncreaseStats(moodIncreaseConsumption, Stats.Mood);
        OnValueChanged();
    }

    public void IncreaseSleepyConsumption()
    {
        _statsValueChanger.IncreaseStats(sleepyIncreaseConsumption, Stats.Sleepy);
        OnValueChanged();
    }
}