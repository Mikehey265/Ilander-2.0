using System;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public static Fuel Instance { get; private set; }

    public static Action OnThrustPerformed;
    
    [SerializeField] private float maxFuelCapacity = 1000f;
    private float _currentFuelCapacity;
    private float _amountFuelUsed = 1f;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentFuelCapacity = maxFuelCapacity;
    }
    
    private void OnEnable()
    {
        OnThrustPerformed += DecreaseFuel;
    }

    private void OnDisable()
    {
        OnThrustPerformed -= DecreaseFuel;
    }

    public float GetCurrentFuelCapacity()
    {
        return _currentFuelCapacity;
    }

    public float GetMaxFuelCapacity()
    {
        return maxFuelCapacity;
    }

    public void ModifyFuelUsage(float amount)
    {
        _amountFuelUsed = amount;
    }

    private void DecreaseFuel()
    {
        _currentFuelCapacity -= _amountFuelUsed;
        FuelBarUI.OnFuelModified?.Invoke();
    }
}
