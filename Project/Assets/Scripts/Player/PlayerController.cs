using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Animator anim;
    private bool inAttack;
    private MeleeWeapon meleeWeapon;
    private Rigidbody rb;
    private Vector3 startTouchPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        meleeWeapon = GetComponentInChildren<MeleeWeapon>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(!inAttack)
            Move();
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("Kick"); 
    }

    private void Move()
    {
        float velocityX = Input.GetAxis("Vertical");
        float velocityZ = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(velocityZ, 0, velocityX) * moveSpeed;
        rb.velocity = direction;

        if (direction != Vector3.zero)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
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
