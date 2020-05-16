using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float totalTime;
    private float remainingTime;

    private bool initState;
    private bool state4;
    private bool state3;
    private bool state2;
    private bool state1;
    private bool emptyState;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        remainingTime = totalTime;
        initState = false;
        state4 = false;
        state3 = false;
        state2 = false;
        state1 = false;
        emptyState = false;
    }

    void Update()
    {
        LoseTime();
        TimeState();
        UpdateAnimation();
    }

    void LoseTime()
    {
        remainingTime -= Time.deltaTime;
    }

    void TimeState()
    {
        if (totalTime > remainingTime)
        {
            initState = true;
        }

        if (totalTime/ (4 / 5) > remainingTime)
        {
            state4 = true;
        }

        if (totalTime / (3 / 5) > remainingTime)
        {
            state3 = true;
        }

        if (totalTime / (2 / 5) > remainingTime)
        {
            state2 = true;
        }

        if (totalTime / (1 / 5) > remainingTime)
        {
            state1 = true;
        }

        if (0.0f > remainingTime)
        {
            emptyState = true;
        }
    }

    void UpdateAnimation()
    {
        anim.SetBool("initState", initState);
        anim.SetBool("state4", state4);
        anim.SetBool("state3", state3);
        anim.SetBool("state2", state2);
        anim.SetBool("state1", state1);
        anim.SetBool("emptyState", emptyState);
    }
}
