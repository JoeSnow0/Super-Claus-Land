using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyEntityEditor : Editor
{

}

public class EnemyEntity : Entity
{
    [Header("Enemy Types")]
    [Tooltip("Choose which enemy is to be used by using its index")]
    //[SerializeField] private int myType;
    [SerializeField] private EnemyStats mEnemy;
    [Tooltip("Add new enemies to the list")]

    EnemyState currentEnemyState;
    PatrolEnemyState patrolEnemyState;
    protected override void Start()
    {

        InitializeEntity(FindObjectOfType<GameController>());
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        mSpriteRenderer.sprite = mEnemy.mSprite;
        mAnimator.runtimeAnimatorController = mEnemy.mAnimationController;
        mVelocity = mEnemy.mSpeed;
        mJumpPower = mEnemy.mJumpPower;
    }
    private void FixedUpdate()
    {
        CheckIfGrounded();
        Move();
        Turn();
        Jump();
    }
    protected override void Update()
    {
        UpdateAnimations();
    }
    protected override void UpdateAnimations()
    {
        mAnimator.SetBool("Dead", isDead);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        mDirection *= -1f;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggeredByPlayer(collision);
        TriggeredByProjectile(collision);
    }
    void TriggeredByPlayer(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerEntity player = collision.gameObject.GetComponent<PlayerEntity>();
            print(player.GetRigidbody().velocity.y);
            //If falling
            if (player.GetRigidbody().velocity.y < 0)
            {
                Death();
            }
        }
    }
    void TriggeredByProjectile(Collider2D collision)
    {
        if (collision.gameObject.tag == "FriendlyProjectile")
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        mRigidbody.sleepMode = RigidbodySleepMode2D.StartAsleep;
        mDirection = 0f;
        Destroy(gameObject, 1f);
    }
}
