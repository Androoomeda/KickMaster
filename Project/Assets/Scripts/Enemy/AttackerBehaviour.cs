using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Animator anim;
    private MeleeWeapon meleeWeapon;
    private EnemyController enemyController;
    private Transform player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        meleeWeapon = GetComponentInChildren<MeleeWeapon>();
        enemyController = GetComponent<EnemyController>();
        player = enemyController.player;
    }

    private void Update()
    {
        if (enemyController.attackMode)
        {
            Attack();
        }
    }

    private void Attack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer >= 1)
        {
             MoveToPlayer();
        }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetTrigger("Punch");
        }
    }

    private void MoveToPlayer()
    {
        anim.SetBool("IsWalking", true);
        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }


    // Animation events
    public void MeleeAttackStart()
    {
        meleeWeapon.AttackStart();
    }

    public void MeleeAttackEnd()
    {
        meleeWeapon.AttackEnd();
    }
}
