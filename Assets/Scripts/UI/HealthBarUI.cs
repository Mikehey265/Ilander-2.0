using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public static Action OnHealthModified;
    
    [SerializeField] private Image healthBar;

    private void OnEnable()
    {
        OnHealthModified += UpdateHealthBar;
    }

    private void OnDisable()
    {
        OnHealthModified -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Health.Instance.GetCurrentHealth() / Health.Instance.GetStartingHealth();
    }
}
