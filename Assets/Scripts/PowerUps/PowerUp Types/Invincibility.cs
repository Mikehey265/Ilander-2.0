using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Invincibility")]
public class Invincibility : PowerUp
{
    public override void ApplyEffect(GameObject target)
    {
        Health.Instance.ModifyDamageTaken(0f);
    }
}
