using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Testing_Scene", LoadSceneMode.Additive);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
