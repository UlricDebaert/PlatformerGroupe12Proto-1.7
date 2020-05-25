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
    private bool canScream;
    [SerializeField]
    private bool male;

    public PlayerHacking PH;
    public PlayerScore PS;
    public SimpleCameraShakeInCinemachine CS;
    public BloodEffect BE;
    public HackedEffect HE;

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
        canScream = true;
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
        CheckHackedEffect();
    }

    void CheckHack()
    {
        if (PH != null && HE != null)
        {
            if (PH.timeOfHack < timeHackLeft)
            {
                HE.hacked = false;
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

    void CheckHackedEffect()
    {
        if (hacked)
        {
            HE.hacked = true;
        }
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
        if (hacked == false && PH != null && HE != null)
        {
            HE.hacked = true;
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
        if (PH != null && CS != null && BE != null && HE != null)
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
            hacked = false;
            HE.hacked = false;
            BE.RedEffect();
            FindObjectOfType<AudioManager>().Play("HackBoom");
            FindObjectOfType<AudioManager>().Play("TêteExplosée");
            CS.StartShake();
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

            if (canScream && male)
            {
                FindObjectOfType<AudioManager>().Play("MaleScream");
                canScream = false;
            }

            if (canScream && !male)
            {
                FindObjectOfType<AudioManager>().Play("FemaleScream");
                canScream = false;
            }

            
        } else
        {
            disappearTimer = 0f;
        }

    }
}
