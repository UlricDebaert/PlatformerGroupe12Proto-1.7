using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScoreButton : MonoBehaviour
{
    private int highScoreReseted;

    private void Start()
    {
        highScoreReseted = 0;
    }

    public void ResetHighScore()
    {
        highScoreReseted = 0;
        PlayerPrefs.SetInt("PlayerHighScore", highScoreReseted);
    }
}
