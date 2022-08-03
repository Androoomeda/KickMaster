using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int hp;

    private ReplaceWithRagdoll replaceWithRagdoll;
    private float externalForce;

    public UnityEvent onDeath;

    System.Action shedule;

    private void Awake()
    {
        TryGetComponent<ReplaceWithRagdoll>(out replaceWithRagdoll);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 10f)
        {
            ApplyDamage();
        }
    }

    public void ApplyDamage()
    {
        hp--;
        if(hp <= 0)
        {
            onDeath.Invoke();
            if (replaceWithRagdoll != null)
                replaceWithRagdoll.Replace();
        }
    }
}
