using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    GameManager gameManager;
    AudioManager audioManager;  // Reference to AudioManager

    private void Awake()
    {
        currentHealth = startingHealth;
        audioManager = FindFirstObjectByType<AudioManager>();  // Find the AudioManager in the scene
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameManager.AdjustEnemiesLeft(-1);
            PlayDeathSound();  // Play sound when enemy dies
            SelfDestruct();
        }
    }

    private void PlayDeathSound()
    {
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.enemiDeath);  // Replace with the appropriate sound name for the enemy death
        }
        else
        {
            Debug.LogWarning("AudioManager not found!");
        }
    }

    public void SelfDestruct()
    {
        Instantiate(robotVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
