using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadLevel()  //Carga la escena del nivel
    {
        SceneManager.LoadScene("Level"); 
    }
    public void LoadMenu()  //Carga la escena del Menu
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()  //Cierra la aplicación
    {
        Application.Quit();
    }
}
