using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected float maxHealth;

    public float Health { get; protected set; }

    private void Start()
    {
        Health = initialHealth;
    }

    public void TakeDamage(float damageQuantity)
    {
        if (damageQuantity > 0)
        {
            Health -= damageQuantity;
            UpdateHealthBar(Health, maxHealth);
            if (Health <= 0)
            {
                Health = 0;
                PlayerDefeated();
            }
        }
        return;
    }

    protected virtual void UpdateHealthBar(float currentHealth, float maxHealth)
    { 
        
    }

    protected virtual void PlayerDefeated()
    { 

    }
}
