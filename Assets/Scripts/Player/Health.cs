using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    
    [SerializeField] private float startHealthAmount = 100f;
    private float _currentHealthAmount;
    private float damageAmount = 20f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentHealthAmount = startHealthAmount;
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
    
    public void Heal(float healAmount)
    {
        _currentHealthAmount += healAmount;
        HealthBarUI.OnHealthModified?.Invoke();
    }

    public void ModifyDamageTaken(float amount)
    {
        damageAmount = amount;
    }
    
    private void TakeDamage()
    {
        _currentHealthAmount -= damageAmount;
        HealthBarUI.OnHealthModified?.Invoke();
    }
}
