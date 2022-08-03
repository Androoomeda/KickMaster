using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawner;
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private float throwForce;
    [SerializeField] private float throwTimeOut;

    private Transform player;
    private float countDown = 0;
    private EnemyController enemyController;
    private Animator anim;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        player = enemyController.player;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (countDown > 0)
            countDown -= Time.deltaTime;

        if (enemyController.attackMode && countDown <= 0)
        {
            anim.SetTrigger("Throw");
        }
    }


    // Animation event
    public void Throw()
    {
        countDown = throwTimeOut;
        anim.ResetTrigger("Throw");
        GameObject projectile = Instantiate(projectiles[Random.Range(0, projectiles.Length)], projectileSpawner.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce((player.position - projectileSpawner.position) * throwForce, ForceMode.Impulse);
    }
}
