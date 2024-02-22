using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpWindowTime = 0.5f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private float _jumpPressedTime = 0f;
    private bool _isJumping = false;
    private Vector2 _flipScale;

    private void Awake()
    {
        _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        _flipScale = transform.localScale;
    }

    private void Update()
    {
        Move();
        Flip();
        Jump();
    }

    private void Flip()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector2(_flipScale.x * Mathf.Sign(Input.GetAxisRaw("Horizontal")), transform.localScale.y);
        }
    }

    private void Move()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        float distance = direction * _speed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") != 0f && _rigidbody2D.velocity.y == 0f)
        {
            _isJumping = true;
            _jumpPressedTime = 0f;
        }

        if (_isJumping)
        {
            _jumpPressedTime += Time.deltaTime;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);

            if(_jumpPressedTime > _jumpWindowTime || Input.GetAxis("Jump") == 0f)
            {
                _isJumping = false;
            }
        }
    }
}
