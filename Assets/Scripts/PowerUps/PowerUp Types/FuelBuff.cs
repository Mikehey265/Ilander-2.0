using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/FuelBuff")]
public class FuelBuff : PowerUp
{
    [SerializeField] private float fuelUseAmount;
    
    public override void ApplyEffect()
    {
        Fuel.Instance.ModifyFuelUsage(fuelUseAmount);
    }

    public override void RemoveEffect()
    {
        Fuel.Instance.ModifyFuelUsage(Fuel.Instance.GetDefaultFuelUsage());
    }
}
