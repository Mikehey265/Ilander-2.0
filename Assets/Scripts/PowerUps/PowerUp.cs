using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public abstract void ApplyEffect();

    public abstract void ResetEffect();
}
