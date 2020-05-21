using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsText : MonoBehaviour
{
    public bool noMoreTime;
    public bool notEnoughMicroship;

    public Text tipsText;

    void Update()
    {
        if (noMoreTime)
        {
            tipsText.text = "Tips : You have to finish before Time runs out.";
        }

        if (notEnoughMicroship)
        {
            tipsText.text = "Tips : You must bring more than 30 Microships.";
        }
    }
}
