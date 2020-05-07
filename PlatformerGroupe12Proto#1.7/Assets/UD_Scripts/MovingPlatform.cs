using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 9f;

    //public bool goUp;
    private bool playerIsOnMe;

    public Transform Pos1, Pos2;
    public Transform startPos;

    Vector3 nextPos;

    [SerializeField]
    private PlayerController PC;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        nextPos = startPos.position;
        //goUp = false;
    }

    void Update()
    {
        if (transform.position == Pos1.position)
        {
            nextPos = Pos2.position;
            //goUp = false;

        }

        if (nextPos == Pos1.position)
        {
            if (PC.isOnMovingPlatform && playerIsOnMe)
            {
                Player.SendMessage("GoDown");
            }
        }

        if (transform.position == Pos2.position)
        {
            nextPos = Pos1.position;
            //goUp = true;
            if (PC.isOnMovingPlatform && playerIsOnMe)
            {
                Player.SendMessage("GoUp");
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Pos1.position, Pos2.position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsOnMe = true;
            PC.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsOnMe = false;
            PC.isGrounded = false;
        }
    }
}
