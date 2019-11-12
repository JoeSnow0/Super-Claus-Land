using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    enum PowerUp {Small, Big, Fireflower}
    
    PowerUp mPowerUp;
    private KeyboardInput playerInput;
    private float mVelocityMax;
    private bool mIsDucking;
    protected override void Start()
    {
        mJumpPower.x = 0.0f;
        mJumpPower.y = 8.0f;
        mVelocityMax = mVelocity + 5.0f;
        //playerInput = GetComponent<KeyboardInput>();
        mRigidbody = GetComponent<Rigidbody2D>();
    }
    protected override void Update()
    {
        mDirection = GetDirection();
        mAnimator.SetFloat("Speed", Mathf.Abs(mDirection));
        mAnimator.SetBool("Grounded", mIsGrounded);
        mAnimator.SetBool("Down", mIsDucking);
        if(mIsDucking == false)
        {
            Move();
        }
        
        Turn();
        if (Input.GetKey(KeyCode.DownArrow) && mIsGrounded == true)
        {
            Duck(true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Duck(false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && mIsGrounded == true)
        {
            Jump();
        }
        
 
    }
    float GetDirection()
    {
        float inputDirection = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputDirection = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputDirection = 1f;
        }
        return inputDirection;
    }
    private void Duck(bool state)
    {
        mIsDucking = state;
    }
    private void SetState(States state)
    {
        mState = state;
    }
    private void SetState(PowerUp powerUp)
    {
        mPowerUp = powerUp;
    }
}
