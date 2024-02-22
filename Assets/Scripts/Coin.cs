using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Rigidbody2D>().TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            Destroy(gameObject);
        }
    }
}
