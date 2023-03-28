using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    [SerializeField] private GameObject notification;
    [SerializeField] private Image messageBackground;
    [SerializeField] private Text alertText;
    [SerializeField] private Button closeButton;
    [SerializeField] private Color color;

    public virtual void OnEnable()
    {
        notification.gameObject.SetActive(false);
        closeButton.onClick.AddListener(CloseAlert);
        messageBackground.color = color;
    }

    public virtual void OnDisable()
    {
        closeButton.onClick.RemoveListener(CloseAlert);
    }

    private void CloseAlert()
    {
        notification.gameObject.SetActive(false);
    }
    
    public void ShowMessage(string message)
    {
        alertText.text = message;
        notification.gameObject.SetActive(true);
    }
}
