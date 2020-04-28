using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacked : MonoBehaviour
{
    private float timeHackLeft;

    public bool hacked;
    private bool canExplode;

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

    void Start()
    {
        hacked = false;
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
    }

    void CheckHack()
    {
        if (PH.timeOfHack < timeHackLeft)
        {
            hacked = false;
            PH.amountOfHack += 1;
            timeHackLeft = 0f;
            canExplode = false;
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
        if (hacked == false)
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
        if (PH.boom==true && hacked)
        {
            Boom();
        }

    }

    public void Boom()
    {
        Debug.Log("Boom");
        if (hacked)
        {
            PH.amountOfHack += 1;
            PS.score += 1;
            ownIA.dead = true; //Repérage par les autres si disparu
            gameObject.SetActive(false);
        }
    }

    private void Disappear()
    {
        if(otherIA1.dead || otherIA2.dead || otherIA3.dead || otherIA4.dead)
        {
            gameObject.SetActive(false);
        }
    }
}
