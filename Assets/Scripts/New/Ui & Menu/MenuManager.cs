using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject LevelPanel;
    public GameObject MenuPanel;

    public void PlayMechanics()
    {
        SceneManager.LoadScene("GamePlayMechanicsProto");
    }
    public void PlayLevelDesignProto()
    {
        SceneManager.LoadScene("LevelDesignProto");
    }
    public void PlayPrototypeLevel()
    {
        SceneManager.LoadScene("Prototype Level");
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void Level7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void Level8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Play()
    {
        LevelPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
    public void Back()
    {
        LevelPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
