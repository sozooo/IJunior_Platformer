using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode _vampirismHotKey;

    private const string HorizontalAxis = "Horizontal";
    private const string JumpAxis = "Jump";

    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;

    private Vector2 _flipScale;
    private Rigidbody2D _rigidbody2D;

    public event Action OnVampirismEnable;

    private bool IsGrounded => _rigidbody2D.velocity.y == 0f;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _flipScale = transform.localScale;
    }

    private void Update()
    {
        if(IsGrounded)
            _playerAnimation.Grounded(IsGrounded);

        if (Input.GetKeyDown(_vampirismHotKey))
        {
            OnVampirismEnable?.Invoke();
        }

        Move();
        Flip();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Move()
    {
        if(Input.GetAxisRaw(HorizontalAxis) != 0f)
        {
            float direction = Input.GetAxisRaw(HorizontalAxis);

            _playerMovement.Move(direction);
            _playerAnimation.Run(IsGrounded);
        }
        else if (IsGrounded)
        {
            _playerAnimation.Idle();
        }

    }

    private void Jump()
    {
        float yVelocity = _rigidbody2D.velocity.y;

        _playerMovement.Jump(Input.GetAxisRaw(JumpAxis) != 0f && IsGrounded, _rigidbody2D);
        _playerAnimation.Jump(yVelocity > 0f && Input.GetAxisRaw(JumpAxis) != 0, yVelocity, IsGrounded);
        _playerAnimation.Fall(yVelocity < 0f, yVelocity, IsGrounded);
    }

    private void Flip()
    {
        if (Input.GetAxisRaw(HorizontalAxis) != 0)
        {
            transform.localScale = new Vector2(_flipScale.x * Mathf.Sign(Input.GetAxisRaw(HorizontalAxis)), transform.localScale.y);
        }
    }
}
