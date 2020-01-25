using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEntity : Entity
{
    public enum playerState { Small, Big, Fireflower, Dead }

    [Header("Starting PowerUp")]
    [SerializeField] playerState mSetInitialState;
    [SerializeField] playerState mCurrentState;
    playerState mPreviousState;
    private KeyboardInput mPlayerInput;
    [SerializeField] private ProjectileEntity mFireballPrefab;
    float mPreviousDirection = 1f;
    float iFrameSeconds = 2f;
    bool isInvincible = false;
    protected override void Start()
    {
        mJumpForce.y = mJumpPower;
        SetState(mSetInitialState);
        mPlayerInput = mGameController.GetComponent<KeyboardInput>();
    }
    private void FixedUpdate()
    {
        GetDirection();
        CheckIfGrounded();
        Move();
        Turn();
        Jump();
        VariableJumping();
    }
    protected override void Update()
    {
        ClearInput();
        GetInput();
        UpdateAnimations();
        Shooting();
    }
    private void ClearInput()
    {
        mKeyDuck    = false;
        mKeyJump    = false;
        mKeyJumpHeld = false;
        mKeyLeft    = false;
        mKeyRight   = false;
        mKeyRun     = false;
    }
    private void GetInput()
    {
        mKeyJump        = IsKeyPressed(mPlayerInput.jumpKey);
        mKeyShoot       = IsKeyPressed(mPlayerInput.shootKey);
        mKeyJumpHeld    = IsKeyHeld(mPlayerInput.jumpKey);
        mKeyDuck        = IsKeyHeld(mPlayerInput.downKey);
        mKeyLeft        = IsKeyHeld(mPlayerInput.leftKey);
        mKeyRight       = IsKeyHeld(mPlayerInput.rightKey);
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
        float inputDirection = 0f;
        if (mKeyLeft)
        {
            inputDirection = -1f;
        }
        if (mKeyRight)
        {
            inputDirection = 1f;
        }
        mDirection = inputDirection;
        if (mDirection != 0f)
        {
            mPreviousDirection = mDirection;
        }
    }
    private void Duck(bool state)
    {
        mKeyDuck = state;
    }
    protected override void UpdateAnimations()
    {
        mAnimator.SetFloat("Direction", mDirection);
        mAnimator.SetFloat("Speed", Mathf.Abs(mForce.x));
        mAnimator.SetFloat("Velocity", mRigidbody.velocity.x);
        mAnimator.SetBool("Grounded", mIsGrounded);
        mAnimator.SetBool("Down", mKeyDuck);
        

    }
    private void SetState(playerState newState)
    {
        mPreviousState = mCurrentState;
        mCurrentState = newState;
        if (mCurrentState == playerState.Fireflower)
        {
            mAnimator.SetBool("FireFlower", true);
        }
        
        else if (mCurrentState == playerState.Big)
        {
            mAnimator.SetBool("Big", true);
        }
        else if (mCurrentState == playerState.Small)
        {
            mAnimator.SetBool("Small", true);
        }
    }
    private void LateUpdate()
    {
        mAnimator.SetBool("Small", false);
        mAnimator.SetBool("Big", false);
        mAnimator.SetBool("FireFlower", false);
    }
    private playerState GetState()
    {
        return mCurrentState;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CollisionWithEnemy(collision.gameObject);
        CollisionWithItem(collision);
        
    }
    private void CollisionWithEnemy(GameObject collisionTarget)
    {
        if (collisionTarget.tag == "Enemy")
        {
            EnemyEntity enemy = collisionTarget.GetComponent<EnemyEntity>();
            if (!enemy.isDead && GetState() != playerState.Dead && mRigidbody.velocity.y >= 0)
            {
                if ((int)GetState() > (int)playerState.Small && !isInvincible)
                {
                    SetState(playerState.Small);
                    StartCoroutine(invincibility(iFrameSeconds));
                }
                else if ((int)GetState() == (int)playerState.Small && !isInvincible)
                {
                    Death();
                }
            }
        }
    }

    void Death()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        SetState(playerState.Dead);
        gameObject.SetActive(false);
    }

    private void CollisionWithItem(Collision2D collision)
    {
        if (collision.gameObject.tag == "Friendly")
        {
            ItemEntity item = collision.gameObject.GetComponent<ItemEntity>();
            
            if((int)GetState() <= (int)item.setMarioState)
            {
                print((int)GetState() + "<current state || new state>" + (int)item.setMarioState);
                SetState(item.setMarioState);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionWithEnemy(collision.gameObject);
        if (collision.gameObject.tag == "InstantDeath")
        {
            Death();
        }
    }
    void Shooting()
    {
        if (!mKeyShoot || GetState() != playerState.Fireflower) return;

        ProjectileEntity newProjectile = Instantiate(mFireballPrefab, transform);
        newProjectile.transform.position = new Vector3(transform.position.x + mPreviousDirection * mSpriteRenderer.size.x * 0.5f, transform.position.y, transform.position.z);
        newProjectile.transform.SetParent(null);
        newProjectile.initializeProjectile(mPreviousDirection);

    }
    private IEnumerator invincibility(float time)
    {
        
        isInvincible = true;
        print("Invincible: " + isInvincible);
        yield return new WaitForSeconds(time);
        isInvincible = false;
        print("Invincible: " + isInvincible);
    }
}
