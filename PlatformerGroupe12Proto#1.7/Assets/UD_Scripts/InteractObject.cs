using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public PlayerScore PS;
    public PlayerAttack PA;

    public bool dead = false;
    private bool nearPlayer = false;

    public void Start()
    {
        dead = false;
        nearPlayer = false;
    }

    //Transplanter ce script dans Hacked pour éciter le bug de perte de hack quand tué au cac alors que hacked
    /*public void Kill()
    {
        gameObject.SetActive(false);
        PS.score+=1;
    }*/ //Plus Utile car relatif au PlayerInteract *OBSOLETE*

    public void FixedUpdate()
    {
        if(PA != null)
        {
            if (nearPlayer && PA.isAttacking)
            {
                PS.score += 1;
                dead = true;
                gameObject.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            nearPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearPlayer = false;
        }
    }
}
