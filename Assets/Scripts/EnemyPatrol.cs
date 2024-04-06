using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;

    private List<Transform> _wayPoints = new List<Transform>();
    private Transform _endPoint;
    private int _currentPoint = 1;

    private void Awake()
    {
        foreach (Transform wayPoint in _way)
            _wayPoints.Add(wayPoint);
    }

    public void Patrol()
    {
        if (_currentPoint >= _wayPoints.Count)
        {
            _currentPoint = 0;
        }
        
        _endPoint = _wayPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, _endPoint.position, _speed * Time.deltaTime);

        if(transform.position == _endPoint.position)
        {
            _currentPoint++;
            Flip();
        }
    }

    private void Flip()
    {
        Vector2 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }
}
