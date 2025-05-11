using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject quitButton;

    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    AudioManager audioManager;  // Reference to AudioManager

    private void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();  // Find the AudioManager in the scene
    }

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
            restartButton.SetActive(true);
            quitButton.SetActive(true);
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);

            PlayWinSound();  // Play sound when all enemies are defeated
        }
    }

    private void PlayWinSound()
    {
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.Win);  // Replace with the appropriate win sound name
        }
        else
        {
            Debug.LogWarning("AudioManager not found!");
        }
    }

    public void RestartlevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Ui Manager");
    }
}
