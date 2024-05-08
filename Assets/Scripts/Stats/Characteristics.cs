using System;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _knockBack;

    private float _currentHealth;

    public float Damage => _damage;
    public float MaxHealth => _maxHealth;
    public float KnockBack => _knockBack;
    private float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;

            OnHealthChanged?.Invoke(_currentHealth);
        }
    }

    public event Action<float> OnHealthChanged;
    public event Action<Characteristics> OnDeath;

    private void Start()
    {
        _currentHealth = _maxHealth;

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void Heal(float restoreAmount)
    {
        CurrentHealth = Mathf.Clamp(_currentHealth + restoreAmount, 0f, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _maxHealth);

        if (_currentHealth == 0f)
            Dead();
    }

    public void Dead()
    {
        OnDeath?.Invoke(transform.GetComponent<Characteristics>());

        Destroy(gameObject);
    }
}
