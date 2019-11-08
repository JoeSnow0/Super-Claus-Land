using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : Movement 
{

    private KeyboardInput playerInput;

    private void Update()
    {
        mVelocity = new Vector2(10.0f, 0.0f);
        mDirection = GetDirection();
        Move();
    }
    float GetDirection()
    {
        float inputDirection =  0.0f;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputDirection = -90.0f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputDirection = 90.0f;
        }
        return inputDirection;
    }
}
