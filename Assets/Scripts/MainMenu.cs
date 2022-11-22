using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Easy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//add scene params here
    }

    public void Normal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//add scene params here
    }

    public void Hard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//add scene params here
    }
}
