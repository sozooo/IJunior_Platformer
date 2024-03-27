using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _knockBack;

    private Rigidbody2D _rigidbody2D;
    private float _health;

    public float Damage => _damage;
    public float Health => _maxHealth;
    public float KnockBack => _knockBack;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = _maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Attacker>(out Attacker attacker))
        {
            _health -= attacker.Damage;

            if(_health == 0)
            {
                Destroy(gameObject);
            }

            _rigidbody2D.AddForce(new Vector2(-attacker.KnockBack * transform.localScale.x, attacker.KnockBack), ForceMode2D.Impulse);
        }
    }

    public void Heal(float restoreAmount)
    {
        _health += restoreAmount;

        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}
