using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int Score = 0;

    private Text ScoreText;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    public void AddScore(int scoreIncrease)
    {
        Score += scoreIncrease;

        ScoreText.text = $"Score : {Score}";
    }
}
