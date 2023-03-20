using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayGame : MonoBehaviour
{
    [SerializeField] private Button button;
    
    private RatingDisplayer _ratingDisplayer;

    public void Init(RatingDisplayer ratingDisplayer)
    {
        _ratingDisplayer = ratingDisplayer;
        
        button.onClick.AddListener(_ratingDisplayer.OnPlayGame);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(_ratingDisplayer.OnPlayGame);
    }
}
