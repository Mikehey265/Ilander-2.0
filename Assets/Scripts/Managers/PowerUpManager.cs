using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance { get; private set; }

    public static Action OnPowerUpCollected;
    public static Action OnPowerUpExpired;

    [SerializeField] private int maxActivePowerUps;

    private List<PowerUp> _activePowerUpList;
    private PowerUpTrigger _powerUpTrigger;

    private void Awake()
    {
        Instance = this;
        _activePowerUpList = new List<PowerUp>();
        _powerUpTrigger = GetComponent<PowerUpTrigger>();
    }
}
