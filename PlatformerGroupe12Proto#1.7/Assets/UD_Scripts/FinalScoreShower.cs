using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreShower : MonoBehaviour
{
    private int scoreToShow;

    [SerializeField]
    ScoreCalculator SC;
    public Text scoreText;

    private void Start()
    {
    }

    void Update()
    {
        int scoreToShow = (int)SC.totalScore;
        scoreText.text = scoreToShow.ToString();
    }
}
