using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject systemsRootPrefab;

    private void Awake()
    {
        if (FindObjectsByType<Bootstrap>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        if (systemsRootPrefab != null)
        {
            Instantiate(systemsRootPrefab);
        }
        else
        {
            GameObject go = new GameObject("G");
            go.AddComponent<G>();
        }
        
        SceneManager.LoadScene("MainMenu");
    }
}
