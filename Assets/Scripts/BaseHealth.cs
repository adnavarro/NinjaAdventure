using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected float maxHealth;

    public float Health { get; protected set; }

    protected virtual void Start()
    {
        Health = initialHealth;
    }

    public void TakeDamage(float damageQuantity)
    {
        if (damageQuantity > 0)
        {
            Health -= damageQuantity;
            if (Health <= 0)
            {
                Health = 0;
                PlayerDefeated();
            }
            UpdateHealthBar(Health, maxHealth);
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
