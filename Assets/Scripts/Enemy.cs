using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol _enemyPatrol;
    private PlayerDetector _playerDetector;
    private EnemyMovement _enemyMovement;
    private Player _player;

    private bool _isPlayerFound => _player != null;

    private void Awake()
    {
        _enemyPatrol = transform.GetComponent<EnemyPatrol>();
        _playerDetector = transform.GetComponent<PlayerDetector>();
        _enemyMovement = transform.GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (_isPlayerFound)
        {
            _enemyMovement.MoveToAim(_player);
        }
        else
        {
            _enemyPatrol.Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(_isPlayerFound == false)
            _player = _playerDetector.Detect();
    }
}
