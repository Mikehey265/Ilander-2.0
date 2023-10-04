using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Invincibility")]
public class Invincibility : PowerUp
{
    public override void ApplyEffect()
    {
        Health.Instance.ModifyDamageTaken(0f);
    }

    public override void ResetEffect()
    {
        Health.Instance.ModifyDamageTaken(Health.Instance.GetDefaultDamageAmount());
    }
}
