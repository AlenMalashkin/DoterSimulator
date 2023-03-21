using UnityEngine;
using UnityEngine.UI;

public class RatingDisplayer : MonoBehaviour, IRatingObserver
{
    [SerializeField] private Text ratingDisplay;
    
    private int _rating = 10;
    
    private void OnEnable()
    {
        _rating = PlayerPrefs.GetInt("Rating", 10);
        
        ratingDisplay.text = _rating + "";
    }

    public void OnRatingChanged(int rating)
    {
        ratingDisplay.text = rating + "";
    }
}
