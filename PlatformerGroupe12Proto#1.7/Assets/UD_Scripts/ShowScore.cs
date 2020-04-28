using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    [SerializeField]
    PlayerScore PS;
    public Text scoreText;

    void Update()
    {
        scoreText.text = PS.score.ToString();
    }
}
