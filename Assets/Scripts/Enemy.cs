using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol enemyPatrol;
    private PlayerDetector playerDetector;
    private EnemyMovement enemyMovement;
    private Player player;

    private bool isPlayerFound => player != null;

    private void Awake()
    {
        enemyPatrol = transform.GetComponent<EnemyPatrol>();
        playerDetector = transform.GetComponent<PlayerDetector>();
        enemyMovement = transform.GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (isPlayerFound)
        {
            enemyMovement.MoveToAim(player);
        }
        else
        {
            enemyPatrol.Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(isPlayerFound == false)
            player = playerDetector.Detect();
    }
}
