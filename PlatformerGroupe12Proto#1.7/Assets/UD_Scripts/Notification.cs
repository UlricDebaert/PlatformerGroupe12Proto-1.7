using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    private bool visible;

    private float visibleTimer;
    [SerializeField]
    private float visibleTime;

    [SerializeField]
    private Animator anim;

    void Start()
    {
        visible = false;
        visibleTimer = 0.0f;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
        UpdateVisibleTime();
    }

    void UpdateAnimation()
    {
        anim.SetBool("visible", visible);
    }

    void UpdateVisibleTime()
    {
        if (visible)
        {
            visibleTimer += Time.deltaTime;
        }
        else
        {
            visibleTimer = 0.0f;
        }

        if (visibleTimer >= visibleTime)
        {
            visible = false;
        }
    }

    public void Appear()
    {
        visible = true;
    }
}
