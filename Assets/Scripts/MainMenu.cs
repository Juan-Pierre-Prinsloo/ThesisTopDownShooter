using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Easy()
    {
        GameMasterScript.Difficulty = "Easy";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Normal()
    {
        GameMasterScript.Difficulty = "Normal";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Hard()
    {
        GameMasterScript.Difficulty = "Hard";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
