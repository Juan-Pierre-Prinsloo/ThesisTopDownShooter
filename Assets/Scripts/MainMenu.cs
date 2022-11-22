using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string Difficulty;

   public void Easy()
    {
        Difficulty = "Easy";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Normal()
    {
        Difficulty = "Normal";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Hard()
    {
        Difficulty = "Hard";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
