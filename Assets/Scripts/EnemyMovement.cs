using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void MoveToAim(Player aim)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(aim.transform.position.x, transform.position.y), _speed * Time.deltaTime);
    }
}
