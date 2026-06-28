using UnityEngine;

public class GameEnterButtonsManager : MonoBehaviour
{
    public void OnContinueButtonPressed()
    {
        G.Instance.SceneLoader.LoadScene("HUB");
    }
    
    public void OnNewGameButtonPressed()
    {
        G.Instance.SaveSystem.ResetGameSave();
        G.Instance.SceneLoader.LoadScene("HUB");
    }
}
