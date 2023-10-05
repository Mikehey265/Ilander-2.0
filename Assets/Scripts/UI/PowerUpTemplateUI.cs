using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpTemplateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI powerUpNameText;
    [SerializeField] private Image timer;

    private void Update()
    {
        timer.fillAmount = PowerUpManager.Instance.GetPowerUpTimerNormalized();
    }

    public void SetPowerUp(PowerUp powerUp)
    {
        powerUpNameText.text = powerUp.name;
    }
}
