using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEntity : Entity
{
    enum PowerUp { Small, Big, Fireflower }


    PowerUp mPowerUp;
    [SerializeField] private KeyboardInput mplayerInput;
    private float mVelocityMax;
    
    protected override void Start()
    {
        mJumpPower.x = 0.0f;
        mJumpPower.y = 8.0f;
        mVelocityMax = mVelocity + 5.0f;
        mplayerInput = mGameController.GetComponent<KeyboardInput>();
        mRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        ClearInput();
        GetInput();
        GetDirection();
        CheckIfGrounded();
        Move();
        Turn();
        Jump();
    }
    protected override void Update()
    {
        UpdateAnimations();
    }
    private void ClearInput()
    {
        mKeyDuck    = false;
        mKeyJump    = false;
        mKeyLeft    = false;
        mKeyRight   = false;
        mKeyRun     = false;
    }
    private void GetInput()
    {
        mKeyJump    = IsKeyPressed(mplayerInput.jumpKey);
        mKeyDuck    = IsKeyHeld(mplayerInput.downKey);
        mKeyLeft    = IsKeyHeld(mplayerInput.leftKey);
        mKeyRight   = IsKeyHeld(mplayerInput.rightKey);
    }
    private bool IsKeyPressed(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool IsKeyHeld(KeyCode key)
    {
        if (Input.GetKey(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool IsKeyReleased(KeyCode key)
    {
        if (Input.GetKeyUp(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void GetDirection()
    {
        float inputDirection = 0.0f;
        if (mKeyLeft)
        {
            inputDirection = -1f;
        }
        if (mKeyRight)
        {
            inputDirection = 1f;
        }
        mDirection = inputDirection;
    }
    private void Duck(bool state)
    {
        mKeyDuck = state;
    }
    protected override void UpdateAnimations()
    {
        mAnimator.SetFloat("Direction", mDirection);
        mAnimator.SetFloat("Speed", Mathf.Abs(mForce.x));
        mAnimator.SetBool("Grounded", mIsGrounded);
        mAnimator.SetBool("Down", mKeyDuck);
    }
    private void SetState(PowerUp powerUp)
    {
        mPowerUp = powerUp;
    }
}
