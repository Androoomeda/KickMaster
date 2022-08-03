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
        CheckInput();
    }

    private void CheckInput()
    {
        Vector3 direction = Vector3.zero;
        if(Input.touchCount > 0)
        {
            Vector3 currentTouchPos = Vector3.zero;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (startTouchPos != Camera.main.ScreenToWorldPoint(touch.position))
            {
                currentTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
                direction = new Vector3((currentTouchPos - startTouchPos).x, 0, (currentTouchPos - startTouchPos).y);
                rb.velocity = direction * moveSpeed;
            }
            if (touch.phase == TouchPhase.Ended)
                anim.SetTrigger("Kick");
        }

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
