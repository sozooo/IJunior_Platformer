using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _flipScale;

    private void Awake()
    {
        _flipScale = transform.localScale;
    }

    public void MoveToAim(Player aim)
    {
        Flip(aim.transform);

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(aim.transform.position.x, transform.position.y), _speed * Time.deltaTime);
    }

    public void Flip(Transform aim)
    {
        transform.localScale = new Vector2(_flipScale.x * Mathf.Sign(aim.transform.position.x - transform.position.x), transform.localScale.y);
    }
}
