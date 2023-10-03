using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }

    private static int playerCount;
    
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
        playerCount++;
        Debug.Log(playerCount);
    }

    private void OnDisable()
    {
        GameManager.OnRocketHit -= TakeDamage;
        playerCount--;
    }

    public float GetCurrentHealth()
    {
        return _currentHealthAmount;
    }

    public float GetStartingHealth()
    {
        return startHealthAmount;
    }

    public int GetPlayerCount()
    {
        return playerCount;
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
