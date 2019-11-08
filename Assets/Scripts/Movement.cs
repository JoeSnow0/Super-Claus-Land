using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Speed & Direction
    protected Vector2 mVelocity;
    protected Transform mTransform;
    protected Vector2 mPosition;
    protected float mDirection;
  
    private void Start()
    {
        mPosition = new Vector2(0.0f, 0.0f);
        mTransform = GetComponent<Transform>();
    }
    
    private void CalculateNewPosition()
    {
        mVelocity.x = 10.0f;
        mVelocity.y = mDirection;
        mPosition = mVelocity * Time.deltaTime;
    }
    protected void Move()
    {
        CalculateNewPosition();
        mTransform.position = mPosition;
    }
    protected void MoveTo(Vector2 newPosition)
    {
        mTransform.position = newPosition;
    }

}


