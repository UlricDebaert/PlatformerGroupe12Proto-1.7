using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float score = 0f;
    [SerializeField]
    private float totalScore;

    [SerializeField]
    Timer Ti;

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
        PlayerPrefs.SetFloat("PlayerScore", score);   
        PlayerPrefs.SetFloat("TotalScore", totalScore);   
    }

    void PointCalculate()
    {
        totalScore = score * Ti.remainingTime;
    }
}
