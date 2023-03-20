using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Alert _alert;
    private StatsValueChanger _statsValueChanger;

    private Dictionary<Stats, string> _messagesMap = new Dictionary<Stats, string>()
    {
        {Stats.Hungry, "Вы слишком голодны! улучшите свои показатели в течении следующих 5-и ходов или умрете с голоду!"},
        {Stats.Mood, "У вас слишком плохое настроение! улучшите свои показатели в течении следующих 5-и ходов или вас замучает депрессия!"},
        {Stats.Sleepy, "Вы слишком сонный! улучшите свои показатели в течении следующих 5-и ходов или умрете от недосыпа!"},
    };
    
    public void Init(Alert alert, StatsValueChanger statsValueChanger)
    {
        _alert = alert;
        _statsValueChanger = statsValueChanger;
        
        _statsValueChanger.OnStatsValueChangedEvent += OnStatsValueChanged;
    }

    private void OnDisable()
    {
        _statsValueChanger.OnStatsValueChangedEvent -= OnStatsValueChanged;
    }

    private void OnStatsValueChanged(float value, Stats stat)
    {
        if (value <= 0f)
        {
            _alert.ShowAlert(_messagesMap[stat]);
        }
    }
}
