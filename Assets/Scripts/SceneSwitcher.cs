using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Object scene;
    [SerializeField] private bool additiveMode;

    private string sceneName;

    // Start is called before the first frame update
    private void Start()
    {
        sceneName = scene.name;
    }

    public void SwitchScene()
    {
        if (additiveMode)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}