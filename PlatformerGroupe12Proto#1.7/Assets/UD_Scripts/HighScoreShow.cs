using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreShow : MonoBehaviour
{
    [SerializeField]
    ScoreCalculator SC;
    public Text highScoreText;
    private int highScore;
    private int pastHighScore;
    private int newHighScore;

    void Start()
    {
        pastHighScore = PlayerPrefs.GetInt("PlayerHighScore");
    }

    void Update()
    {
        if (SC != null)
        {
            if (SC.totalScore >= pastHighScore)
            {
                int newHighScore = (int)SC.totalScore;
                PlayerPrefs.SetInt("PlayerHighScore", newHighScore);
                highScoreText.text = newHighScore.ToString();
            }
            else
            {
                highScoreText.text = pastHighScore.ToString();
            }
        }
    }
}
