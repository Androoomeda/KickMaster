using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    EnemyController enemyController = enemy.GetComponent<EnemyController>();
                    enemyController.SetAttackMode();
                }
            }
        }
    }
}
