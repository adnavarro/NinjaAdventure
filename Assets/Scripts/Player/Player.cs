using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerHealth PlayerHealth { get; private set; }
    public PlayerAnimation PlayerAnimation { get; private set; }

    private void Awake()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerAnimation = GetComponent<PlayerAnimation>();
    }

    public void RestorePlayer()
    {
        PlayerHealth.RestorePlayer();
        PlayerAnimation.RestorePlayerAnimation();
    }
}
