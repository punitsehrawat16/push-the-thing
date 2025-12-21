using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
   public void GameRestart()
    {
        SceneManager.LoadScene("Prototype Level");
    }
}
