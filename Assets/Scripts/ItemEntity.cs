using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : Entity
{
    [Header("Item")]
    [Tooltip("Choose which Item you wish for this to be")]
    [SerializeField] Item mItem;

    override protected void Start()
    {
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
        mSprite.sprite = mItem.mSprite;
        if (mItem.mMoves)
        {
            mDirection = 1f;
            mForce.x = 1f;
        }
    }
}
