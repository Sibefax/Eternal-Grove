using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnQuitButtonPressed()
    {
        G.Instance.SceneLoader.ExitGame();
    }
}
