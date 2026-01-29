using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelPause : MonoBehaviour
{
    [FormerlySerializedAs("PausePanel")] public GameObject PauseMePanel;
    public GameObject GamePanel;


    public void Pause()
    {
        Time.timeScale = 0f;
        PauseMePanel.SetActive(true);
        GamePanel.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMePanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
