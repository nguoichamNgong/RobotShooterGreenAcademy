using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        bool isPaused = Time.timeScale == 0;

        if (isPaused)
        {
            Continue();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
