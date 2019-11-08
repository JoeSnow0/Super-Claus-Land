using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Speed & Direction
    protected float mVelocity;
    protected Transform mTransform;
    protected Collider2D mCollider;
    protected Bounds mBounds;
    protected GameObject mGameObject;
    protected Vector2 mPosition;
    protected float mDirection;
    protected float mGravity = 0.0f;
    protected float mGravityDirection = -1.0f;
  
    virtual protected void Start()
    {
        
    }
    virtual protected void Update()
    {

    }


    private void CalculateNewPosition()
    {
        mPosition.x = mTransform.position.x + mVelocity * mDirection * Time.deltaTime;
        mPosition.y = mTransform.position.y + mGravity * mGravityDirection * Time.deltaTime;
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

    private void Collision(Collider2D otherCollider)
    {
        if (mCollider.IsTouching(otherCollider))
        {

        }
    }

}


