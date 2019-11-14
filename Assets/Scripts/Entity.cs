using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    //Outside References
    protected GameController mGameController;
    //Speed & Direction
    protected enum States { Standing, Walking, Ducking, Jumping };

    protected States mState;
    [Range(0.0f, 100.0f)]
    [SerializeField] protected float mVelocity;
    [SerializeField] protected Vector2 mJumpPower;
    protected Transform mTransform;
    protected Animator mAnimator;
    [SerializeField] protected bool mIsGrounded;
    protected SpriteRenderer mSprite;
    protected Collider2D mCollider;
    protected GameObject mGameObject;
    protected Vector2 mForce;

    protected float mDirection;
    protected float mGravity = 0.0f;
    protected float mGravityDirection = -1.0f;
    protected Rigidbody2D mRigidbody;
    //Jumping and falling
    protected float mFallMultiplier = 1.5f;
    protected float mLowJumpMultiplier = 1.2f;

        //
    protected bool mKeyDuck;
    protected bool mKeyJump;
    protected bool mKeyLeft;
    protected bool mKeyRight;
    protected bool mKeyRun;

    Vector2 vectorPoint1;
    Vector2 vectorPoint2;
    [SerializeField] protected LayerMask groundLayer;

    protected Vector2Int mPos;

    virtual protected void Start()
    {
       
    }
    virtual protected void Update()
    {
        
    }
    public void InitializeEntity(GameController controller)
    {
        mGameController = controller;
        mSprite = GetComponent<SpriteRenderer>();
        mAnimator = GetComponent<Animator>();
        mTransform = GetComponent<Transform>();
        mCollider = GetComponent<Collider2D>();
    }
    private void CalculateNewMovementForce()
    {
        mForce.x = mVelocity * mDirection;
    }
    private void CalculateNewJumpForce()
    {
        mJumpPower.x = mVelocity * mDirection;
    }
    protected void Move()
    {
        if (mKeyDuck)
        {
            return;
        }
        CalculateNewMovementForce();
        mRigidbody.AddRelativeForce(mForce, ForceMode2D.Force);
    }
    protected void Jump()
    {
        if(mIsGrounded && mKeyJump)
        {
            mRigidbody.AddRelativeForce(mJumpPower, ForceMode2D.Impulse);
        }
    }
    protected void Turn()
    {
        if(mDirection < 0)
        {
            if(mSprite.flipX != false)
            {
                mSprite.flipX = false;
            }
            
        }
        else if (mDirection > 0)
        {
            if (mSprite.flipX != true)
            {
                mSprite.flipX = true;
            }
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
    protected void CheckIfGrounded()
    {
        vectorPoint1 = new Vector2(transform.position.x - mSprite.bounds.size.x * 0.4f, transform.position.y);
        vectorPoint2 = new Vector2(transform.position.x + mSprite.bounds.size.x * 0.4f, transform.position.y - (mSprite.bounds.size.y * 0.51f));
        mIsGrounded = Physics2D.OverlapArea(vectorPoint1, vectorPoint2, groundLayer);
    }
    virtual protected void UpdateAnimations()
    {

    }


    //Editor Debug
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0, 0.5f);
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y), new Vector2(vectorPoint2.x - vectorPoint1.x , vectorPoint2.y - vectorPoint1.y));
    }
}
