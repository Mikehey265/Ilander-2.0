using System;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public static Fuel Instance { get; private set; }

    public static Action OnThrustPerformed;
    
    [SerializeField] private float maxFuelCapacity = 1000f;
    [SerializeField] private float defaultFuelUsage = 1f;
    private float _currentFuelCapacity;
    private float _currentFuelUsage;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentFuelCapacity = maxFuelCapacity;
        _currentFuelUsage = defaultFuelUsage;
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

    public float GetDefaultFuelUsage()
    {
        return defaultFuelUsage;
    }

    public void ModifyFuelUsage(float amount)
    {
        _currentFuelUsage = amount;
    }

    private void DecreaseFuel()
    {
        _currentFuelCapacity -= _currentFuelUsage;
        FuelBarUI.OnFuelModified?.Invoke();
    }
}
