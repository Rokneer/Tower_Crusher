using UnityEngine;
public class MenuPausa : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    private bool IsPaused = false;

    void Start()
    {
        Unpause();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) Unpause();
            else Pause();
        }
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        IsPaused = false;
    }
    void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        IsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Principal");
    }
}
