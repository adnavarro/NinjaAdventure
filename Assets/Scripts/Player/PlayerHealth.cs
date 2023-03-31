using System;
using UnityEngine;

public class PlayerHealth : BaseHealth
{
    private BoxCollider2D _boxCollider2D;
    public bool IsAbleToHeal => Health < maxHealth;
    public bool IsPlayerDefeated { get; private set; }
    public static Action PlayerDefeatedEvent;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateHealthBar(Health, maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void RestoreHealth(float quantityToRestore)
    {
        if (IsPlayerDefeated)
        { 
            return;
        }

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
        UIManager.Instance.UpdatePlayerHealth(currentHealth, maxHealth);
    }

    public void RestorePlayer()
    {
        _boxCollider2D.enabled = true;
        IsPlayerDefeated = false;
        Health = initialHealth;
        UpdateHealthBar(Health, initialHealth);
    }

    protected override void PlayerDefeated()
    {
        IsPlayerDefeated = true;
        _boxCollider2D.enabled = false;
        PlayerDefeatedEvent?.Invoke();
    }
}
