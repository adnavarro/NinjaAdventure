using UnityEngine;

public class PlayerHealth : BaseHealth
{
    public bool IsAbleToHeal => Health < maxHealth;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            RestoreHealth(10);
        }
    }

    public void RestoreHealth(float quantityToRestore)
    { 
        if (IsAbleToHeal)
        {
            if (Health + quantityToRestore > maxHealth)
            {
                Health = maxHealth;
            }
            else
            {
                Health += quantityToRestore;
            }
        }
    }

    protected override void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        base.UpdateHealthBar(currentHealth, maxHealth);
    }
}
