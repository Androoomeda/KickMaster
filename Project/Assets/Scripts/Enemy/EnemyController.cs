using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player { get; private set; }
    public bool attackMode { get; private set; } = false;

    private Damageable damageable;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        RotateToPlayer();
        if(damageable.hp <= 0)
        {
            GameManager.instance.enemiesCount--;
        }
    }

    private void RotateToPlayer()
    {
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    public void SetAttackMode()
    {
        attackMode = true;
    }
}
