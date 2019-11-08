using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement 
{

    private KeyboardInput playerInput;
    private float mVelocityMax;
    protected override void Start()
    {
        mPosition = new Vector2(0.0f, 0.0f);
        mVelocity = 5.0f;
        mVelocityMax = mVelocity + 5.0f;
        mTransform = GetComponent<Transform>();
        playerInput = GetComponent<KeyboardInput>();
        mBounds = mCollider.bounds;
    }
    protected override void Update()
    {
        mDirection = GetDirection();
        Move();
    }
    float GetDirection()
    {
        float inputDirection =  0.0f;
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
    void Acceleration()
    {

    }
    void deceleration()
    {

    }
}
