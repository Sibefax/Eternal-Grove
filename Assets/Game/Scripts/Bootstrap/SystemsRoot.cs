using UnityEngine;

public class SystemsRoot : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject resourceManager;
    public GameObject timeManager;
    public GameObject eventBus;
    public GameObject saveSystem;
    public GameObject sceneLoader;
    public GameObject buildingManager;
    public GameObject uiManager;
    public GameObject inputListener;

    private void Awake()
    {
        Instantiate(gameManager);
        Instantiate(resourceManager);
        Instantiate(timeManager);
        Instantiate(eventBus);
        Instantiate(saveSystem);
        Instantiate(sceneLoader);
        Instantiate(buildingManager);
        Instantiate(uiManager);
        Instantiate(inputListener);
    }
}
