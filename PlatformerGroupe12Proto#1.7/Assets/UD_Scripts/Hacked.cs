using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacked : MonoBehaviour
{
    private float timeHackLeft;
    private float disappearTimer;

    public bool hacked;
    private bool canExplode;
    public bool boom;
    public bool disappear;

    public PlayerHacking PH;
    public PlayerScore PS;

    [SerializeField]
    private InteractObject ownIA;

    [SerializeField]
    private InteractObject otherIA1;
    [SerializeField]
    private InteractObject otherIA2;
    [SerializeField]
    private InteractObject otherIA3;
    [SerializeField]
    private InteractObject otherIA4;

    private Animator anim;

    void Start()
    {
        hacked = false;
        anim = GetComponent<Animator>();
        boom = false;
        disappear = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHack();
        Timer();
        CheckExplosion();

        if ((otherIA1 != null) || (otherIA2 != null) || (otherIA3 != null) || (otherIA4 != null))
        {
            Disappear();
        }

        UpdateAnimation();
    }

    void CheckHack()
    {
        if (PH != null)
        {
            if (PH.timeOfHack < timeHackLeft)
            {
                hacked = false;
                PH.amountOfHack += 1;
                timeHackLeft = 0f;
                canExplode = false;
            }
        }
    }

    void UpdateAnimation()
    {
        anim.SetBool("boom", boom);
        anim.SetBool("hacked", hacked);
        anim.SetBool("disappear", disappear);
    }

    void Timer()
    {
        if (hacked == true)
        {
            timeHackLeft += Time.deltaTime;
        }
    }

    public void Hacking()
    {
        if (hacked == false && PH != null)
        {
            hacked = true;
            timeHackLeft = 0;
            PH.amountOfHack -= 1;
            canExplode = true;
        }
        else
        {
            timeHackLeft = 0;
        }
    }

    public void CheckExplosion()
    {
        if (PH != null)
        {
            if (PH.boom == true && hacked)
            {
                Boom();
            }

        }
    }

    public void Boom()
    {
        Debug.Log("Boom");
        if (hacked && !boom)
        {
            FindObjectOfType<AudioManager>().Play("TêteExplosée");
            boom = true;
            PH.amountOfHack += 1;
            PS.score += 1;
            ownIA.dead = true; //Repérage par les autres si disparu
            //gameObject.SetActive(false);
        }
    }

    private void Disappear()
    {
        if((otherIA1.dead || otherIA2.dead || otherIA3.dead || otherIA4.dead) && !ownIA.dead)
        {
            disappear = true;
        }

        if (disappear)
        {
            disappearTimer += Time.deltaTime;
            if (disappearTimer > 1.0f)
            {
                gameObject.SetActive(false);

            }
        } else
        {
            disappearTimer = 0f;
        }

    }
}
