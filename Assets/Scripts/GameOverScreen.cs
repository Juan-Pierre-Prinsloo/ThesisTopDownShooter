using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private Text ScoreText;

    private GameMasterScript GameMaster;

    public void Setup(int score)
    {
        GameMaster = GameObject.FindWithTag("MainCamera").GetComponent<GameMasterScript>();

        GameMaster.GameOver();

        gameObject.SetActive(true);
        
        ScoreText = gameObject.transform.Find("GameOverScoreText").GetComponent<Text>();

        ScoreText.text = $"Score : {score}";
    }

    public void DynamicDifficultyBtn()
    {
        GameMasterScript.Difficulty = "Dynamic";

        SceneManager.LoadScene("Game");
    }

    public void SurveyBtn()
    {
        Application.OpenURL("https://forms.gle/d9VYzSLSqNgdnsh29");
    }
}
