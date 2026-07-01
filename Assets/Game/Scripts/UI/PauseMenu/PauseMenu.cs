using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
    [SerializeField] private GameObject pauseMenu;
    
    private bool _isPaused;

    private void OnEnable()
    {
        G.Instance.InputListener.OnEscapePressed += TogglePause;
    }

    private void OnDisable()
    {
        G.Instance.InputListener.OnEscapePressed -= TogglePause;
    }

    private void TogglePause()
    {
        if (_isPaused) 
        {
            OnPauseExit();
        } 
        else 
        {
            OnPauseEnter();
        }
    }

    private void OnPauseEnter() 
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        _isPaused = true;
    }

    public void OnPauseExit() 
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        _isPaused = false;
    }

    public void OnQuitButtonPressed() 
    {
        Time.timeScale = 1;
        G.Instance.SaveSystem.SaveGame();
        G.Instance.SceneLoader.LoadScene("MainMenu");
    }
}
