using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public bool inAttack { get; private set; }

    [SerializeField] private Transform followTarget;
    [SerializeField] private float damage;
    [SerializeField] private float force;
    [SerializeField] private float radius;

    

    private void Update()
    {
        transform.position = followTarget.position;
        Attack();
    }

    private void Attack()
    {
        if (inAttack)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var collider in colliders)
            {
                CheckDamage(collider);
            }
        }
    }

    private void CheckDamage(Collider collider)
    {
        Rigidbody rb = collider.attachedRigidbody;
        Damageable damageable = collider.gameObject.GetComponent<Damageable>();
        if (collider.gameObject.layer != gameObject.layer)
        {
            if (damageable != null)
                damageable.ApplyDamage();

            if (rb != null)
                rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(transform.position, radius);
    }

    public void AttackStart()
    {
        inAttack = true;
    }

    public void AttackEnd()
    {
        inAttack = false;
    }
}
