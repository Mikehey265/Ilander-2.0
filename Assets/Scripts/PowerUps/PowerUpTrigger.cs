using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    [SerializeField] private PowerUp powerUp;
    [SerializeField] private bool shouldHaveTimer;
    [SerializeField] private float powerUpTimer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        // Debug.Log(powerUp.name);
        
        powerUp.ApplyEffect();
        gameObject.SetActive(false);
        
        Invoke(nameof(ResetPowerUpEffect), powerUpTimer);
    }

    private void ResetPowerUpEffect()
    {
        powerUp.ResetEffect();
        Destroy(gameObject);
    }
}
