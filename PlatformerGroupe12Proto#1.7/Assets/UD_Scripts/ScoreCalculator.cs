using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField]
    private float remainingTime;
    [SerializeField]
    private float score;
    [SerializeField]
    private float totalScore;

    void Start()
    {
        score = PlayerPrefs.GetFloat("PlayerScore");
        remainingTime = PlayerPrefs.GetFloat("RemainingTime");
        totalScore = PlayerPrefs.GetFloat("TotalScore");
    }

    void Update()
    {
        
    }
}
