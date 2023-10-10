using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    
    [SerializeField] private float startHealthAmount = 100f;
    [SerializeField] private float defaultDamageAmount = 20f;
    private float _currentHealthAmount;
    private float _currentDamageAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentHealthAmount = startHealthAmount;
        _currentDamageAmount = defaultDamageAmount;
    }
    
    private void OnEnable()
    {
        GameManager.OnRocketHit += TakeDamage;
    }

    private void OnDisable()
    {
        GameManager.OnRocketHit -= TakeDamage;
    }

    public float GetCurrentHealth()
    {
        return _currentHealthAmount;
    }

    public float GetStartingHealth()
    {
        return startHealthAmount;
    }

    public float GetDefaultDamageAmount()
    {
        return defaultDamageAmount;
    }
    
    public void Heal(float healAmount)
    {
        _currentHealthAmount += healAmount;
        HealthBarUI.OnHealthModified?.Invoke();
    }

    public void ModifyDamageTaken(float amount)
    {
        _currentDamageAmount = amount;
    }
    
    private void TakeDamage()
    {
        _currentHealthAmount -= _currentDamageAmount;
        HealthBarUI.OnHealthModified?.Invoke();
    }
}
