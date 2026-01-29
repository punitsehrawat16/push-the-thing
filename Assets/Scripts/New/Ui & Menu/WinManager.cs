using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class WinManager : MonoBehaviour
{
    [FormerlySerializedAs("WinPanel")] public GameObject winPanel;
    public GameObject gamePanel;
    public GameObject guidePanel;

    public void ShowPanel()
    {
        StartCoroutine(WinPanelCoroutine());
    }

    IEnumerator WinPanelCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
    }
    public void ShowGuidePanel()
    {
        Time.timeScale = 0f;
        guidePanel.SetActive(true);
        gamePanel.SetActive(false); 
    }

    public void HideGuidePanel()
    {
        Time.timeScale = 1f;
        guidePanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void Retry()
    {
        gamePanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        if (winPanel.activeSelf)
        {
            winPanel.SetActive(false);
        }
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
