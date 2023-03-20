using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayGame : MonoBehaviour
{
    [SerializeField] private Button button;
    
    [SerializeField] private float hungryConsumption;
    [SerializeField] private float sleepyConsumption;
    [SerializeField] private float moodConsumption;
    
    private RatingDisplayer _ratingDisplayer;
    private IProgressBarObserver[] _progressBars;
    private StatsValueChanger _statsValueChanger;

    public void Init(IProgressBarObserver[] progressBars, RatingDisplayer ratingDisplayer, StatsValueChanger statsValueChanger)
    {
        button = GetComponent<Button>();
        
        _progressBars = progressBars;
        _ratingDisplayer = ratingDisplayer;
        _statsValueChanger = statsValueChanger;
        
        button.onClick.AddListener(() => _statsValueChanger.DecreaseStats(hungryConsumption, Stats.Hungry));
        button.onClick.AddListener(() => _statsValueChanger.DecreaseStats(moodConsumption, Stats.Mood));
        button.onClick.AddListener(() => _statsValueChanger.DecreaseStats(sleepyConsumption, Stats.Sleepy));
        
        button.onClick.AddListener(_ratingDisplayer.OnPlayGame);
        
        foreach (var progressBar in _progressBars)
        {
            button.onClick.AddListener(progressBar.OnValueChanged);
        }
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(_ratingDisplayer.OnPlayGame);
        
        foreach (var progressBar in _progressBars)
        {
            button.onClick.RemoveListener(progressBar.OnValueChanged);
        }
    }
}
