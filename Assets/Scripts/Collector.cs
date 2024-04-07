using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(collision.gameObject);
        }

        if(collision.TryGetComponent<Medkit>(out Medkit medkit))
        {
            Destroy(collision.gameObject);

            transform.GetComponent<Attacker>().Heal(medkit.RestoreAmount);
        }
    }
}
