using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private bool scoreAchieved;

    public float score = 0f;
    [SerializeField]
    private float totalScore;

    [SerializeField]
    Timer Ti;
    [SerializeField]
    Notification No;
    [SerializeField]
    ProgressionSlider PrSl;

    private void Start()
    {
        //score = 0f;
        score = PlayerPrefs.GetFloat("PlayerScore");
    }

    void Update()
    {
        if(Ti != null)
        {
            PointCalculate();
        }
        if((score >= 30 && !scoreAchieved) || Input.GetKeyDown(KeyCode.O))
        {
            No.Appear();
            PrSl.visible = true;
            scoreAchieved = true;
        }
        PlayerPrefs.SetFloat("PlayerScore", score);   
        PlayerPrefs.SetFloat("TotalScore", totalScore);   
    }

    void PointCalculate()
    {
        totalScore = score * (Ti.remainingTime/4);
    }
}
