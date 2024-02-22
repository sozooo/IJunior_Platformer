using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_rigidbody2D.velocity.y == 0f)
        {
            _isGrounded = true;
            _animator.SetBool("Grounded", _isGrounded);
        }

        Fall();
        Run();
        Jump();
        Idle();
    }

    private void Idle()
    {
        if (_isGrounded && Input.GetAxisRaw("Horizontal") == 0f)
        {
            _animator.SetInteger("AnimState", 0);
        }
    }

    private void Jump()
    {
        if (Input.GetAxisRaw("Jump") > 0f && _rigidbody2D.velocity.y > 0f)
        {
            _animator.SetTrigger("Jump");
            _isGrounded = false;
            _animator.SetBool("Grounded", _isGrounded);
        }
    }

    private void Run()
    {
        if(_isGrounded && Input.GetAxisRaw("Horizontal") != 0f)
        {
            _animator.SetInteger("AnimState", 1);
        }
    }

    private void Fall()
    {
        if(_rigidbody2D.velocity.y < 0f)
        {
            _isGrounded = false;
            _animator.SetBool("Grounded", _isGrounded);
            _animator.SetFloat("AirSpeedY", _rigidbody2D.velocity.y);
        }
    }
}
