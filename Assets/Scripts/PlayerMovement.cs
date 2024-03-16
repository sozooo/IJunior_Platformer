using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string JumpAxis = "Jump";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpWindowTime = 0.5f;

    private float _jumpPressedTime = 0f;
    private bool _isJumping = false;

    public void Move(float direction)
    {
        float distance = direction * _speed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);
    }

    public void Jump(bool isJumping, Rigidbody2D rigidbody2D)
    {
        if (isJumping)
        {
            _isJumping = true;
            _jumpPressedTime = 0f;
        }

        if (_isJumping)
        {
            _jumpPressedTime += Time.deltaTime;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _jumpForce);

            if(_jumpPressedTime > _jumpWindowTime || Input.GetAxis(JumpAxis) == 0f)
            {
                _isJumping = false;
            }
        }
    }
}
