using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/GravityModifier")]
public class NoGravity : PowerUp
{
    public override void ApplyEffect()
    {
        RocketMovement.OnGravityModified?.Invoke();
    }

    public override void ResetEffect()
    {
        RocketMovement.OnGravityModified?.Invoke();
    }
}
