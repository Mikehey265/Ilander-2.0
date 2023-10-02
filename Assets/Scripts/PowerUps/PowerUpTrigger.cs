using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    [SerializeField] private PowerUp powerUp;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(gameObject);
        powerUp.ApplyEffect(other.gameObject);
    }
}
