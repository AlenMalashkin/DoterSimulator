using UnityEngine;
using UnityEngine.UI;

public class ImproveSkills : MonoBehaviour
{
    [SerializeField] private float improvedWinrate;
    [SerializeField] private int amountOfHighWinrateGames;
    
    private Button _button;
    private WinrateRegulator _winrateRegulator;
    
    private void OnEnable()
    {
        _button = GetComponent<Button>();
        
        _winrateRegulator = new WinrateRegulator();
        
        _button.onClick.AddListener(RegulateWinrate);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RegulateWinrate);
    }

    private void RegulateWinrate()
    {
        _winrateRegulator.RegulateWinrate(improvedWinrate, amountOfHighWinrateGames);
    }
}
