using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public PlayerScore PS;
    public PlayerAttack PA;
    public Hacked Ha;
    public SimpleCameraShakeInCinemachine CS;
    public BloodEffect BE;
    public HackedEffect HE;
    public GameObject ParticuleSystem;
    private bool StartParticuleEffect;
    private float particuleEffectTimer;

    public bool dead = false;
    private bool nearPlayer = false;

    public void Start()
    {
        dead = false;
        nearPlayer = false;
        ParticuleEffectTimer = 0;
    }

    //Transplanter ce script dans Hacked pour éciter le bug de perte de hack quand tué au cac alors que hacked
    /*public void Kill()
    {
        gameObject.SetActive(false);
        PS.score+=1;
    }*/ //Plus Utile car relatif au PlayerInteract *OBSOLETE*

    public void FixedUpdate()
    {
        if(PA != null && Ha != null && BE != null)
        {
            if (nearPlayer && PA.isAttacking && Ha.boom == false)
            {
                HE.hacked = false;
                PS.score += 1;
                dead = true;
                //gameObject.SetActive(false);
                Ha.boom = true;
                BE.RedEffect();
                ParticuleSystem.SetActive(true);
                StartParticuleEffect.SetActive(true);
                FindObjectOfType<AudioManager>().Play("TêteExplosée");
                CS.StartShake();
            }
        }
        ((ParticuleEffectTimer));
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

    private void ParticuleEffectTimer() 
    {
        if (StartParticuleEffect == true)
        {
            particuleEffectTimer += Time.deltatime;
            

        }
        if (particuleEffectTimer >= 1.0f) 
        {

            StartParticuleEffect = false;
            particuleEffectTimer = 0;
            ParticuleEffect.SetActive (false); 
        }
    }
    
        
        
        


        
        

         
    
    
}
