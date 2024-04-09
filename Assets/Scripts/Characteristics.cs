using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _knockBack;

    private float _health;

    public float Damage => _damage;
    public float Health => _maxHealth;
    public float KnockBack => _knockBack;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Heal(float restoreAmount)
    {
        _health += restoreAmount;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Dead();
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
