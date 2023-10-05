using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance { get; private set; }

    public static Action OnPowerUpCollected;
    public static Action OnPowerUpExpired;
    
    [SerializeField] private float powerUpTimerMax;
    private const int MaxActivePowerUps = 1;
    
    private List<PowerUp> _activePowerUpList;
    private float _powerUpTimer;
    private bool _doesPowerUpHaveTimer;

    private void Awake()
    {
        Instance = this;
        _activePowerUpList = new List<PowerUp>();
    }

    private void Start()
    {
        _powerUpTimer = powerUpTimerMax;
    }

    private void Update()
    {
        if (_doesPowerUpHaveTimer)
        {
            _powerUpTimer -= Time.deltaTime;
            if (_powerUpTimer < 0f)
            {
                _doesPowerUpHaveTimer = false;
                _powerUpTimer = powerUpTimerMax;    
            }
        }
    }
    
    public void AddActivePowerUp(PowerUp powerUp, bool timer)
    {
        if (_activePowerUpList.Count >= MaxActivePowerUps) return;
        if (!timer) return;
        
        _activePowerUpList.Add(powerUp);
        _doesPowerUpHaveTimer = true;
        
        if (_doesPowerUpHaveTimer)
        {
            OnPowerUpCollected?.Invoke();
        }
        
    }
    
    public void RemoveExpiredPowerUp(PowerUp powerUp)
    {
        _activePowerUpList.Remove(powerUp);
        OnPowerUpExpired?.Invoke();
    }

    public float GetPowerUpTimerNormalized()
    {
        return _powerUpTimer / powerUpTimerMax;
    }

    public List<PowerUp> GetPowerUpList()
    {
        return _activePowerUpList;
    }

    public float GetPowerUpTimerMax()
    {
        return powerUpTimerMax;
    }
    
}
