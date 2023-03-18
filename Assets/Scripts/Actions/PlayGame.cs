using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private float hungryConsumption;
    [SerializeField] private float sleepyConsumption;
    [SerializeField] private float moodConsumption;
    
    private RatingDisplayer _ratingDisplayer;
    private IProgressBarObserver[] _progressBars;
    private StatsValueChanger _statsValueChanger;
    private Button _button;

    public void Init(IProgressBarObserver[] progressBars, RatingDisplayer ratingDisplayer, StatsValueChanger statsValueChanger)
    {
        _button = GetComponent<Button>();
        
        _progressBars = progressBars;
        _ratingDisplayer = ratingDisplayer;
        _statsValueChanger = statsValueChanger;
        
        _button.onClick.AddListener(() => _statsValueChanger.DecreaseStats(hungryConsumption, moodConsumption, sleepyConsumption));
        
        _button.onClick.AddListener(_ratingDisplayer.OnPlayGame);
        
        foreach (var progressBar in _progressBars)
        {
            _button.onClick.AddListener(progressBar.OnValueChanged);
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_ratingDisplayer.OnPlayGame);
        
        foreach (var progressBar in _progressBars)
        {
            _button.onClick.RemoveListener(progressBar.OnValueChanged);
        }
    }
}
