using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Characteristics))]
public class Attacker : MonoBehaviour
{
    private Characteristics characteristics;

    private void Awake()
    {
        characteristics = GetComponent<Characteristics>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Characteristics>(out Characteristics attacked))
        {
            DealDamage(attacked);
        }
    }

    private void DealDamage(Characteristics attacked)
    {
        attacked.TakeDamage(characteristics.Damage);

        attacked.transform.GetComponent<Rigidbody2D>().
            AddForce(new Vector2(characteristics.KnockBack * transform.localScale.x, attacked.KnockBack), ForceMode2D.Impulse);
    }
}
