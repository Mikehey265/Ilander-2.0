using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUp
{
    [SerializeField] private float amount;
    
    public override void ApplyEffect()
    {
        if(Health.Instance.GetCurrentHealth() >= 100f) return;
        Health.Instance.Heal(amount);
    }

    public override void RemoveEffect()
    {
        
    }
}
