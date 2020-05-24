using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionSlider : MonoBehaviour
{
    private float playerPositionX;
    public float playerStartPositionX;
    public float levelEndPositionX;
    public Slider slider;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateSliderValue();
    }

    float CalculateSliderValue()
    {
        return (player.transform.position.x - playerStartPositionX) / (levelEndPositionX - playerStartPositionX);
    }
}
