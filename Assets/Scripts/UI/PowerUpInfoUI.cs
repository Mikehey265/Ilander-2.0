using UnityEngine;

public class PowerUpInfoUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform powerUpTemplate;

    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        PowerUpManager.OnPowerUpCollected += UpdateUI;
        PowerUpManager.OnPowerUpExpired += UpdateUI;
    }

    private void OnDisable()
    {
        PowerUpManager.OnPowerUpCollected -= UpdateUI;
        PowerUpManager.OnPowerUpExpired -= UpdateUI;
    }

    private void UpdateUI()
    {
        foreach (Transform child in container)
        {
            if (child == powerUpTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (PowerUp powerUp in PowerUpManager.Instance.GetPowerUpList())
        {
            Transform powerUpTransform = Instantiate(powerUpTemplate, container);
            powerUpTransform.gameObject.SetActive(true);
            powerUpTransform.GetComponent<PowerUpTemplateUI>().SetPowerUp(powerUp);
        }
        
        Show();
    }

    private void Show()
    {
        powerUpTemplate.gameObject.SetActive(true);
    }

    private void Hide()
    {
        powerUpTemplate.gameObject.SetActive(false);
    }
    
}
