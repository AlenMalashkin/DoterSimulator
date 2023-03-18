using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Alert _alert;
    private StatsValueChanger _statsValueChanger;

    public void Init(Alert alert, StatsValueChanger statsValueChanger)
    {
        _alert = alert;
        _statsValueChanger = statsValueChanger;
        
        _statsValueChanger.OnValuesChangedEvent += OnHungryValueChanged;
        _statsValueChanger.OnValuesChangedEvent += OnMoodValueChanged;
        _statsValueChanger.OnValuesChangedEvent += OnSleepyValueChanged;
    }

    private void OnDisable()
    {
        _statsValueChanger.OnValuesChangedEvent -= OnHungryValueChanged;
        _statsValueChanger.OnValuesChangedEvent -= OnMoodValueChanged;
        _statsValueChanger.OnValuesChangedEvent -= OnSleepyValueChanged;
    }

    private void OnHungryValueChanged()
    {
        var value = PlayerPrefs.GetFloat("Hungry", 1f);
        
        if (value <= 0f)
        {
            _alert.ShowAlert("Вы слишком голодны! улучшите свои показатели в течении следующих 5-и ходов или умрете с голоду");
        }
    }

    private void OnSleepyValueChanged()
    {
        var value = PlayerPrefs.GetFloat("Sleepy", 1f);
        
        if (value <= 0f)
        {
            _alert.ShowAlert("Вы слишком сонный! улучшите свои показатели в течении следующих 5-и ходов или умрете от недосыпа");
        }
    }

    private void OnMoodValueChanged()
    {
        var value = PlayerPrefs.GetFloat("Mood", 1f);
        
        if (value <= 0f)
        {
            {
                _alert.ShowAlert("У вас слишком плохое настроение! улучшите свои показатели в течении следующих 5-и ходов или вас замучает депрессия!");
            }
        }
    }
}
