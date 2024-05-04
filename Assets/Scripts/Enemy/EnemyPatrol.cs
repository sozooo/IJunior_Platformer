using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;

    private EnemyMovement enemyMovement;
    private List<Transform> _wayPoints = new List<Transform>();
    private Transform _endPoint;
    private int _currentPoint = 1;

    private void Awake()
    {
        enemyMovement = transform.GetComponent<EnemyMovement>();

        foreach (Transform wayPoint in _way)
            _wayPoints.Add(wayPoint);
    }

    public void Patrol()
    {
        if (_currentPoint >= _wayPoints.Count)
            _currentPoint = 0;
        
        _endPoint = _wayPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, _endPoint.position, _speed * Time.deltaTime);

        if(transform.position == _endPoint.position)
            _currentPoint++;
        
        enemyMovement.Flip(_endPoint);
    }
}
