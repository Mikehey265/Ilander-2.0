using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/FuelBuff")]
public class FuelBuff : PowerUp
{
    [SerializeField] private float fuelUseAmount;
    
    public override void ApplyEffect(GameObject target)
    {
        Fuel.Instance.ModifyFuelUsage(fuelUseAmount);
    }
}
