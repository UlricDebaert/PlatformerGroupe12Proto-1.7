using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPannel : MonoBehaviour
{
    private bool visible;

    [SerializeField]
    private Animator anim;

    void Start()
    {
        visible = false;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetBool("visible", visible);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            visible = true;
        }
    }    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            visible = false;
        }
    }
}
