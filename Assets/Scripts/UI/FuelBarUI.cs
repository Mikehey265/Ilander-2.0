using System;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarUI : MonoBehaviour
{
    public static Action OnFuelModified;
    
    [SerializeField] private Image fuelBar;

    private void OnEnable()
    {
        OnFuelModified += UpdateFuelBar;
    }

    private void OnDisable()
    {
        OnFuelModified -= UpdateFuelBar;
    }

    private void UpdateFuelBar()
    {
        fuelBar.fillAmount = Fuel.Instance.GetCurrentFuelCapacity() / Fuel.Instance.GetMaxFuelCapacity();
    }
}
