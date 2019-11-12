using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Speed & Direction
    protected enum States { Standing, Walking, Ducking, Jumping };

    protected States mState;
    [Range(0.0f, 100.0f)]
    [SerializeField] protected float mVelocity;
    protected Vector2 mJumpPower;
    protected Transform mTransform;
    protected Transform mGroundCheck;
    protected Collider2D mGroundCheckCol;
    protected Animator mAnimator;
    protected bool mIsGrounded;
    protected SpriteRenderer mSprite;
    protected Collider2D mCollider;
    protected GameObject mGameObject;
    protected Vector2 mForce;

    protected float mDirection;
    protected float mGravity = 0.0f;
    protected float mGravityDirection = -1.0f;
    protected Rigidbody2D mRigidbody;

    protected Vector2Int mPos;

    virtual protected void Start()
    {

    }
    virtual protected void Update()
    {
        
    }
    public void InitializeMovement()
    {
        mSprite = GetComponent<SpriteRenderer>();
        mAnimator = GetComponent<Animator>();
        mTransform = GetComponent<Transform>();
        mGroundCheck = GetComponentInChildren<Transform>();
        mGroundCheck.localPosition.Set(0f, mSprite.size.y, 0f);
        mGroundCheckCol = mGroundCheck.gameObject.GetComponent<Collider2D>();
    }
    private void CalculateNewForce()
    {
        mForce.x = mVelocity * mDirection;
    }
    protected void Move()
    {
        CalculateNewForce();
        mRigidbody.AddForce(mForce, ForceMode2D.Force);
    }
    protected void Jump()
    {
        mRigidbody.AddForce(mJumpPower, ForceMode2D.Impulse);
    }
    protected void Turn()
    {
        if(mDirection < 0)
        {
            mSprite.flipX = false;
        }
        else if (mDirection > 0)
        {
            mSprite.flipX = true;
        }
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return mSprite;
    }
    public Transform GetTransform()
    {
        return mTransform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mIsGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        mIsGrounded = false;
    }
}
