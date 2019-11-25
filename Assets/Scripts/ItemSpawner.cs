using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private Animator mAnimator;
    private GameController mGameController;
    private SpriteRenderer mRenderer;
    [Header("Sprites")]
    [SerializeField] private Sprite mActiveSprite;
    [SerializeField] private Sprite mDeactiveSprite;
    [Header("Prefab to Spawn")]
    [SerializeField] ItemEntity mItemPrefab;
    [Header("Set Spawn position of Object")]
    [SerializeField] private Transform mSpawnPoint;
    [Header("Amount of Items in box")]
    [Range(1, 30)]
    [SerializeField] int mAmount = 1;
    private int mTimesTriggered = 0;
    private void Start()
    {
        mGameController = FindObjectOfType<GameController>();
        mRenderer = GetComponent<SpriteRenderer>();
        mAnimator = GetComponent<Animator>();
        mRenderer.sprite = mActiveSprite;
        
        if(mSpawnPoint == null)
        {
            mSpawnPoint = transform;
        }
    }
    private void OnTriggered()
    {
        mTimesTriggered++;
        mAnimator.Play("Block_Bounce");
        //Spawn Item here
        mGameController.CreateEntity(mItemPrefab, mSpawnPoint);
        if(mTimesTriggered >= mAmount)
        {
            mRenderer.sprite = mDeactiveSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<PlayerEntity>())
        {
            return;
        }
        PlayerEntity playerRef = collision.GetComponent<PlayerEntity>();
        if(playerRef.GetRigidbody().velocity.y > 0.01 && mTimesTriggered < mAmount)
        {
            OnTriggered();
        }
    }
}
