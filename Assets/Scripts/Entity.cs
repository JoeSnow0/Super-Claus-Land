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
    private Vector2 vectorA;
    private Vector2 vectorB;
    [SerializeField] protected LayerMask groundLayer;

    protected Vector2Int mPos;

    virtual protected void Start()
    {
       
    }
    virtual protected void Update()
    {
        
    }
    public void InitializeEntity()
    {
        mSprite = GetComponent<SpriteRenderer>();
        mAnimator = GetComponent<Animator>();
        mTransform = GetComponent<Transform>();
        mCollider = GetComponent<Collider2D>();
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
    protected void CheckIfGrounded()
    {
        mIsGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - mCollider.bounds.size.x * 0.5f, transform.position.y * 0.5f),
                                            new Vector2(transform.position.x + mCollider.bounds.size.x * 0.5f, (transform.position.y - mCollider.bounds.size.y) * 0.5f), 
                                            groundLayer);
    }
    virtual protected void UpdateAnimations()
    {

    }


    //Debug
    private void OnDrawGizmos()
    {
        //Gizmos.color = new Color(0,1,0, 0.5f);
        //Gizmos.DrawCube(new Vector2(0f, vectorA.y + vectorB.y * 0.5f), new Vector2(vectorB.x - vectorA.x , vectorB.y - vectorA.y));
    }
}
