using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayRemainGamesWithHighWinrate : MonoBehaviour, IRatingObserver
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        DisplayRemainGamesWithHighWinrateCount();
    }

    public void DisplayRemainGamesWithHighWinrateCount()
    {
        _text.text = "Осталось игр с повышенным винрейтом: " + PlayerPrefs.GetInt("AmountOfGamesWithHighWinrate");
    }
    
    public void OnRatingChanged(int rating)
    {
        DisplayRemainGamesWithHighWinrateCount();
    }
}
