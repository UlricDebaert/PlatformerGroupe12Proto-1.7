using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private Transform attackHitBoxPos;
    [SerializeField]
    private LayerMask whatIsKillable;
    [SerializeField]
    private float attackRadius;

    private bool gotInput;
    public bool isAttacking;

    private Animator anim;

    [SerializeField]
    private PlayerController PC;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
    }

    private void Update()
    {
        CheckAttackInput();
        CheckAttacks();
    }

    private void CheckAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.C) && PC.isGrounded && !PC.isTouchingObstacle && !PC.isTouchingWall)
        {
            if (combatEnabled)
            {
                gotInput = true;
            }
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                anim.SetBool("isAttacking", isAttacking);
            }
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackHitBoxPos.position, attackRadius, whatIsKillable);

        foreach(Collider2D collider2D in detectedObjects)
        {
            collider2D.transform.parent.SendMessage("Die");
        }
    }

    private void FinishAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitBoxPos.position, attackRadius);
    }
}
