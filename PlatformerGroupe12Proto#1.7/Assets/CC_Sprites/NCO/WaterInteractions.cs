using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCO
{
    public class WaterInteractions : MonoBehaviour
    {

        float cooldown = 0.3f;
        float time;

        bool isInWater = false;
        bool canSplash = true;

        [SerializeField] GameObject player = null;
        [SerializeField] GameObject particleEffect = null;

        PlayerController controller = null;

        void Start()
        {
            controller = player.GetComponent<PlayerController>();
            time = cooldown;
        }

        void Update()
        {
            if (isInWater && controller.isMoving)
                Timer();
        }

        void Timer()
        {

            if(isInWater && controller.isMoving && canSplash)
            {
                Instantiate(particleEffect, player.transform.position, Quaternion.identity);
                canSplash = false;
                time = cooldown;
            }
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                canSplash = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                time = cooldown;
                isInWater = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                isInWater = false;
            }
        }
    }
}