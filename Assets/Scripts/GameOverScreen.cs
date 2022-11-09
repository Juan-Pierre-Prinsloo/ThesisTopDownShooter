using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private Text ScoreText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        
        ScoreText = gameObject.transform.Find("GameOverScoreText").GetComponent<Text>();

        ScoreText.text = $"Score : {score}";
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SurveyBtn()
    {
        //implement link to google forms survey
    }
}
