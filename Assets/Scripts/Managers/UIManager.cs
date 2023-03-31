using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Config")]
    [SerializeField] private Image playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    private float currentHealth;
    private float maxHealth;

    private void Update()
    {
        UpdatePlayerUI();
    }

    public void UpdatePlayerHealth(float playerCurrentHealth, float playerMaxHealth)
    {
        currentHealth = playerCurrentHealth;
        maxHealth = playerMaxHealth;
    }

    public void UpdatePlayerUI()
    {
        float healthFillAmount = currentHealth / maxHealth;
        playerHealth.fillAmount = Mathf.Lerp(playerHealth.fillAmount, healthFillAmount, 10f * Time.deltaTime);
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
