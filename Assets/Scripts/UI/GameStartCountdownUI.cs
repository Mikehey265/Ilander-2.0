using System;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownTimerText;
    private int _previousCountdownNumber;

    private void OnEnable()
    {
        GameManager.OnStateChanged += ShowCountdown;
    }

    private void OnDisable()
    {
        GameManager.OnStateChanged -= ShowCountdown;
    }

    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownToStartTimer());
        countdownTimerText.text = countdownNumber.ToString();
    }

    private void ShowCountdown()
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
