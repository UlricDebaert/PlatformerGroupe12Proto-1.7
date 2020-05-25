using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HackedEffect : MonoBehaviour
{
    public Volume volume;

    public float weight = 0f;

    public bool hacked;

    void Start()
    {
        weight = 0f;
        hacked = false;
    }

    void Update()
    {
        volume.weight = Mathf.Clamp(volume.weight, 0f, 1f);
    }

    private void FixedUpdate()
    {
        if (hacked)
        {
            volume.weight = volume.weight + 0.03f;
        }

        if (!hacked)
        {
            volume.weight = volume.weight - 0.06f;
        }
    }


}
