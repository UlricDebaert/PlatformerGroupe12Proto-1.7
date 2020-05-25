using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloodEffect : MonoBehaviour
{
    public Volume volume;

    public float weight = 0f;

    void Start()
    {
        weight = 0f;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            RedEffect();
        }*/
        volume.weight = Mathf.Clamp(volume.weight, 0f, 1f);
    }

    private void FixedUpdate()
    {
        volume.weight = volume.weight - 0.01f;
    }

    public void RedEffect()
    {
        volume.weight = 1f;
    }
}
