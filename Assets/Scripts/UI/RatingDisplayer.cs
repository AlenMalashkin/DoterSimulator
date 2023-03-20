using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RatingDisplayer : MonoBehaviour
{
    [SerializeField] private Text ratingDisplay;
    
    private int _rating = 10;
    
    private void OnEnable()
    {
        _rating = PlayerPrefs.GetInt("Rating", 10);
        
        ratingDisplay.text = _rating + "";
    }

    public void OnPlayGame()
    {
        float num = Random.Range(0f, 1f);

        if (num < 0.55f)
        {
            _rating += 30;
            ratingDisplay.text = _rating + "";
        }
        else
        {
            _rating -= 30;
            
            if (_rating < 10)
                _rating = 10;
            
            ratingDisplay.text = _rating + "";
        }

        PlayerPrefs.SetInt("Rating", _rating);
    }
}
