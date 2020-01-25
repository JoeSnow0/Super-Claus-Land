using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : Entity
{
    [Header("Item")]
    [Tooltip("Choose which Item you wish for this to be")]
    [SerializeField] Item mItem;
    public PlayerEntity.playerState setMarioState;

    override protected void Start()
    {
        //Get default if null
        if(mItem == null)
        {
            //mItem = find"Assets/Scriptable Objects/MushroomObject.asset"
        }
        InitializeItem();
    }
    private void FixedUpdate()
    {
        CheckIfGrounded();
        Move();
        Turn();
        Jump();
    }
    override protected void Update()
    {
        UpdateAnimations();
    }
    override protected void UpdateAnimations()
    {

    }
    void InitializeItem()
    {
        if(mItem != null)
        mSpriteRenderer.sprite = mItem.mSprite;
        if (mItem.mMoves)
        {
            //TASK:Direction should be randomized
            mDirection = 1f;
            mVelocity = mItem.mSpeed;
        }
        if(mItem.mJumps)
        {
            mJumpPower = mItem.mJumpPower;
        }
        setMarioState = mItem.setState;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mGameController.RemoveEntity(this);
        }
        else
        {
            mDirection *= -1;
        }
    }
}

