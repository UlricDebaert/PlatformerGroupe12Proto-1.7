﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameOverScript GOS;
    public TipsText TT;

    [SerializeField]
    private float totalTime;
    [SerializeField]
    private float state5Time;    
    [SerializeField]
    private float state4Time;
    [SerializeField]
    private float state3Time;
    [SerializeField]
    private float state2Time;
    [SerializeField]
    private float state1Time;
    [SerializeField]
    private float stateEmptyTime;
    public float remainingTime;

    private bool initState;
    private bool state5;
    private bool state4;
    private bool state3;
    private bool state2;
    private bool state1;
    private bool emptyState;

    public bool losingTime;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        remainingTime = totalTime;
        initState = false;
        state5 = false;
        state4 = false;
        state3 = false;
        state2 = false;
        state1 = false;
        emptyState = false;

        /*state4Time = totalTime * (4 / 5);
        state3Time = totalTime * (3 / 5);
        state2Time = totalTime * (2 / 5);
        state1Time = totalTime * (1 / 5);
        stateEmptyTime = 0.0f;*/
    }

    void Update()
    {
        LoseTime();
        TimeState();
        UpdateAnimation();
        PlayerPrefs.SetFloat("RemainingTime", remainingTime);
        //Audio();
    }

    void LoseTime()
    {
        if (losingTime)
        {
            remainingTime -= Time.deltaTime;
        }
    }

    void TimeState()
    {
        if (totalTime > remainingTime)
        {
            initState = true;
        }

        if (state5Time > remainingTime)
        {
            state5 = true;
        }        
        
        if (state4Time > remainingTime)
        {
            state4 = true;
        }

        if (state3Time > remainingTime)
        {
            state3 = true;
        }

        if (state2Time > remainingTime)
        {
            state2 = true;
        }

        if (state1Time > remainingTime)
        {
            state1 = true;
        }

        if (stateEmptyTime > remainingTime)
        {
            emptyState = true;
        }

        if(-4 >= remainingTime)
        {
            if((GOS != null) && (TT != null))
            {
                TT.noMoreTime = true;
                remainingTime = totalTime;
                GOS.Lose();
            }
        }
    }

    void UpdateAnimation()
    {
        anim.SetBool("initState", initState);
        anim.SetBool("state5", state5);
        anim.SetBool("state4", state4);
        anim.SetBool("state3", state3);
        anim.SetBool("state2", state2);
        anim.SetBool("state1", state1);
        anim.SetBool("emptyState", emptyState);
        anim.SetBool("losingTime", losingTime);
    }

    /*private void Audio()
    {
        if (0.0f >= remainingTime)
        {
            FindObjectOfType<AudioManager>().Play("EndTime");
        }
    }*/
}
