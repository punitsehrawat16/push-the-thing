using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public GameObject WinPanel;

    public void ShowPanel()
    {
        Time.timeScale = 0f;
        WinPanel.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        if (WinPanel.activeSelf)
        {
            WinPanel.SetActive(false);
        }
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
