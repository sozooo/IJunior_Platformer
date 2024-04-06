using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(PlayerDetector))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyPatrol enemyPatrol;
    [SerializeField] private PlayerDetector playerDetector;

    private Player player;

    private void Awake()
    {
        enemyPatrol = transform.GetComponent<EnemyPatrol>();
        playerDetector = transform.GetComponent<PlayerDetector>();
    }

    private void Update()
    {
        if (player == null)
        {
            enemyPatrol.Patrol();
            player = playerDetector.Detect();
        }
        else
        {
            //chase
        }
    }
}
