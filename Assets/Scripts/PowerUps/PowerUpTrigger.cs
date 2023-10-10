using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    [SerializeField] private PowerUp powerUp;
    [SerializeField] private bool shouldHaveTimer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log(powerUp.name);
        PowerUpManager.Instance.AddActivePowerUp(powerUp, shouldHaveTimer);
        
        powerUp.ApplyEffect();
        gameObject.SetActive(false);
        
        Invoke(nameof(ResetPowerUpEffect), PowerUpManager.Instance.GetPowerUpTimerMax());
    }

    private void ResetPowerUpEffect()
    {
        powerUp.RemoveEffect();
        PowerUpManager.Instance.RemoveExpiredPowerUp(powerUp);
        Destroy(gameObject);
    }
}
