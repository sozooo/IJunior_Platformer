using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string GroundedBool = "Grounded";
    private const string AnimState = "AnimState";
    private const string JumpTrigger = "Jump";
    private const string AirSpeedY = "AirSpeedY";
    private const int IdleState = 0;
    private const int RunState = 1;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Grounded(bool isGrounded)
    {
        _animator.SetBool(GroundedBool, isGrounded);
    }

    public void Idle()
    {
        _animator.SetInteger(AnimState, IdleState);
    }

    public void Jump(bool isJumping, bool isGrounded)
    {
        if (isJumping)
        {
            _animator.SetTrigger(JumpTrigger);
            _animator.SetBool(GroundedBool, isGrounded);
        }
    }

    public void Run(bool isRunning)
    {
        if(isRunning)
        {
            _animator.SetInteger(AnimState, RunState);
        }
    }

    public void Fall(bool isFaling, float velocity, bool isGrounded)
    {
        if(isFaling)
        {
            _animator.SetFloat(AirSpeedY, velocity);
            _animator.SetBool(GroundedBool, isGrounded);
        }
    }
}
