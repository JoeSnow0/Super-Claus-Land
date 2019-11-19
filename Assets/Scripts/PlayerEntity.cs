using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEntity : Entity
{
    enum PowerUp { Small, Big, Fireflower }


    PowerUp mPowerUp;
    [SerializeField] private KeyboardInput mPlayerInput;
    private float mVelocityMax;
    
    protected override void Start()
    {
        mJumpForce.y = mJumpPower;
        mVelocityMax = mVelocity + 5.0f;
        mPlayerInput = mGameController.GetComponent<KeyboardInput>();
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
        VariableJumping();
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
        mKeyJump = IsKeyPressed(mPlayerInput.jumpKey);
        mKeyJumpHeld    = IsKeyHeld(mPlayerInput.jumpKey);
        mKeyDuck    = IsKeyHeld(mPlayerInput.downKey);
        mKeyLeft    = IsKeyHeld(mPlayerInput.leftKey);
        mKeyRight   = IsKeyHeld(mPlayerInput.rightKey);
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

    private void VariableJumping()
    {
        if (mRigidbody.velocity.y < 0)
        {
            mRigidbody.velocity = new Vector2(mRigidbody.velocity.x, Vector2.up.y * Physics2D.gravity.y * (mFallMultiplier - 1.0f));
        }
        else if (mRigidbody.velocity.y > 0 && !mKeyJumpHeld)
        {
            mRigidbody.velocity = new Vector2(mRigidbody.velocity.x, Vector2.up.y * Physics2D.gravity.y * (mLowJumpMultiplier - 1.0f));
        }
    }
}
