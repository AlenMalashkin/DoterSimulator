using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingDisplayer : MonoBehaviour, IRatingObserver
{
    [SerializeField] private Text ratingDisplay;
    [SerializeField] private Image rangImage;
    
    private int _rating = 10;
    private RangIcons _rangIcons;

    public void OnEnable()
    {
        _rating = PlayerPrefs.GetInt("Rating", 10);
        
        ratingDisplay.text = _rating + "";
        
        _rangIcons = new RangIcons();
        
        DisplayCurrentRatingAndRang(_rating);
    }

    private void DisplayCurrentRatingAndRang(int rating)
    {
        ratingDisplay.text = rating + "";
        
        foreach (KeyValuePair<Range, string> entry in _rangIcons.rangIconsPath)
        {
            Range range = entry.Key;
            string path = entry.Value;

            if (range.Contains(rating))
            {
                rangImage.sprite = Resources.Load<Sprite>(path);
                break;
            }
        }
    }

    public void OnRatingChanged(int rating)
    {
        DisplayCurrentRatingAndRang(rating);
    }
}
