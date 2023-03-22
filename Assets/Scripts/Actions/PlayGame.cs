using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayGame : MonoBehaviour
{
    private Button _button;

    private IRatingObserver[] _ratingObservers;

    private WinrateRegulator _winrateRegulator;

    public void Init(IRatingObserver[] ratingObservers)
    {
        _button = GetComponent<Button>();
        
        _ratingObservers = ratingObservers;
        
        _button.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        float num = Random.Range(0f, 1f);

        var rating = PlayerPrefs.GetInt("Rating", 10);
        
        if (num < PlayerPrefs.GetFloat("Winrate"))
        {
            rating += 30;
        }
        else
        {
            rating -= 30;
            
            if (rating < 10)
                rating = 10;
        }

        PlayerPrefs.SetInt("Rating", rating);

        foreach (var ratingObserver in _ratingObservers)
        {
            ratingObserver.OnRatingChanged(rating);
        }
    }
}