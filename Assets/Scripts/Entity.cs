using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    //Outside References
    protected GameController mGameController;
    //Speed & Direction
    //protected enum States { Standing, Walking, Ducking, Jumping };

    //protected States mState;

    
    //Component References
    protected Transform mTransform;
    protected Animator mAnimator;
    protected SpriteRenderer mSprite;
    protected Collider2D mCollider;
    protected GameObject mGameObject;
    protected Rigidbody2D mRigidbody;

    //Movement
    [Header("Run Speed")]
    [Range(0.0f, 30.0f)]
    [SerializeField] protected float mVelocity;
    [SerializeField]protected float mDirection;
    protected Vector2 mForce = Vector2.zero;

    //Jumping and falling
    [Header("Jump Height")]
    [Range(0.0f, 30.0f)]
    [SerializeField] protected float mJumpPower;
    protected Vector2 mJumpForce;
    protected float mFallMultiplier = 1.5f;
    protected float mLowJumpMultiplier = 1.2f;

    //Ground Checking
    private Vector2 vectorPoint1;
    private Vector2 vectorPoint2;
    [SerializeField] protected bool mIsGrounded;
    [Header("Ground")]
    [Tooltip("Anything considered ground should have this layer attached.")]
    [SerializeField] protected LayerMask groundLayer;

    //Keybindings //NEED TO MOVE TO PLAYER ENTITY SOMEHOW or does it?
    protected bool mKeyDuck;
    protected bool mKeyJump;
    protected bool mKeyJumpHeld;
    protected bool mKeyLeft;
    protected bool mKeyRight;
    protected bool mKeyRun;
    
    

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
        mGameObject = GetComponent<GameObject>();
        mRigidbody = GetComponent<Rigidbody2D>();
    }
    private void CalculateNewMovementForce()
    {
        mForce.x = mVelocity * mDirection;
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
            mRigidbody.AddRelativeForce(mJumpForce, ForceMode2D.Impulse);
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
    public Rigidbody2D GetRigidbody()
    {
        return mRigidbody;
    }
    protected void CheckIfGrounded()
    {
        vectorPoint1 = new Vector2(transform.position.x - mSprite.bounds.size.x * 0.4f, transform.position.y - (mSprite.bounds.size.y * 0.4f));
        vectorPoint2 = new Vector2(transform.position.x + mSprite.bounds.size.x * 0.4f, transform.position.y - (mSprite.bounds.size.y * 0.55f));
        mIsGrounded = Physics2D.OverlapArea(vectorPoint1, vectorPoint2, groundLayer);
    }
    virtual protected void UpdateAnimations()
    {

    }


    //Editor Debug
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0, 0.5f);
        Gizmos.DrawCube(new Vector2(transform.position.x, vectorPoint2.y), new Vector2(vectorPoint2.x - vectorPoint1.x , vectorPoint2.y - vectorPoint1.y));
    }
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
