using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuInput : MonoBehaviour
{
    [SerializeField] public string startScene;
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
