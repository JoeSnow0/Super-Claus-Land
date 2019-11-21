using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private GameController mGameController;
    [Header("")]
    [SerializeField] ItemEntity mItemPrefab;
   
    [Header("Set Spawn position of Object")]
    [SerializeField] private Transform mSpawnPoint;
    [Header("Amount of Items in box")]
    [Range(1, 30)]
    [SerializeField] int mAmount = 1;
    private int mTimesTriggered = 0;
    Animator mAnimator;
    private void Start()
    {
        mGameController = FindObjectOfType<GameController>();
        if(mSpawnPoint == null)
        {
            mSpawnPoint = this.transform;
        }
    }
    private void OnTriggered()
    {
        if (mTimesTriggered < mAmount)
        {
            mTimesTriggered++;
            //Spawn Item here
            mGameController.CreateEntity(mItemPrefab, mSpawnPoint);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<PlayerEntity>())
        {
            return;
        }
        PlayerEntity playerRef = collision.GetComponent<PlayerEntity>();

        if(playerRef.GetRigidbody().velocity.y > 0.01)
        {
            OnTriggered();
        }
    }
}
