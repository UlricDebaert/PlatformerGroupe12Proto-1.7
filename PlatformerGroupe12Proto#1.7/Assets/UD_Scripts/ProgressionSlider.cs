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

    public bool visible;

    [SerializeField]
    private Animator anim;

    void Start()
    {
        visible = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        slider.value = CalculateSliderValue();
        UpdateAnimation();
    }

    float CalculateSliderValue()
    {
        return (player.transform.position.x - playerStartPositionX) / (levelEndPositionX - playerStartPositionX);
    }

    void UpdateAnimation()
    {
        anim.SetBool("visible", visible);
    }
}
