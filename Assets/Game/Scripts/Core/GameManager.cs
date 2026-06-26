using UnityEngine;

public class G : MonoBehaviour
{
    public static G Instance { get; private set; }

    public ResourceManager ResourceManager { get; private set; }
    public TimeManager TimeManager { get; private set; }
    public EventBus EventBus { get; private set; }
    public SaveSystem SaveSystem { get; private set; }
    public BuildingManager BuildingManager { get; private set; }
    public UIManager UIManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeSystems();
    }

    private void InitializeSystems()
    {
        ResourceManager = GetComponentInChildren<ResourceManager>() ?? gameObject.AddComponent<ResourceManager>();
        TimeManager = GetComponentInChildren<TimeManager>() ?? gameObject.AddComponent<TimeManager>();
        EventBus = GetComponentInChildren<EventBus>() ?? gameObject.AddComponent<EventBus>();
        SaveSystem = GetComponentInChildren<SaveSystem>() ?? gameObject.AddComponent<SaveSystem>();
        BuildingManager = GetComponentInChildren<BuildingManager>() ?? gameObject.AddComponent<BuildingManager>();
        UIManager = GetComponentInChildren<UIManager>() ?? gameObject.AddComponent<UIManager>();
    }
}