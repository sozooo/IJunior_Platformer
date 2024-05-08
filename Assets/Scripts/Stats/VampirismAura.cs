using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class VampirismAura : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private SpriteRenderer _auraSprite;

    private CircleCollider2D _circleCollider;
    private List<Characteristics> _affected = new List<Characteristics>();

    public List<Characteristics> Affected => _affected;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        _circleCollider.radius = _radius;

        Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Characteristics>(out Characteristics enemyCharacteristics))
        {
            enemyCharacteristics.OnDeath += RemoveEnemyOnDeath;

            _affected.Add(enemyCharacteristics);
            Debug.Log("added");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Characteristics>(out Characteristics enemyCharacteristics))
        {
            _affected.Remove(enemyCharacteristics);
        }
    }

    public void Activate()
    {
        _circleCollider.enabled = true;
        _auraSprite.enabled = true;
    }

    public void Deactivate()
    {
        _circleCollider.enabled = false;
        _auraSprite.enabled = false;
    }

    private void RemoveEnemyOnDeath(Characteristics enemy)
    {
        _affected.Remove(enemy);
    }
}
