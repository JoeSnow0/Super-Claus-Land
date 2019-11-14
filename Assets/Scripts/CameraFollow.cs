using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameController mGameController;
    private Vector3 mPosition;
    private Entity mTarget;
    private Bounds mBounds;
    private float boundsMultiplier = 15.0f;
    private float cameraSpeed = 10.0f;
    [SerializeField] private float zOffset = -10.0f;
    [SerializeField] private float yOffset = 2.0f;

    
    public void InitializeCamera(GameController controller, Entity target, Bounds bounds)
    {
        mGameController = controller;
        SetTarget(target);
        SetBounds(target);
    }
    private void SetTarget(Entity target)
    {
        mTarget = target;
        mPosition.y = yOffset;
        mPosition.z = zOffset;
    }
    private void SetBounds(Entity target)
    {
        mBounds.extents = target.GetSpriteRenderer().size * boundsMultiplier;
    }
    private void MoveCamera()
    {
        mBounds.center = this.transform.position;
        mPosition.x = Mathf.Lerp(GetPosition().x, mTarget.GetTransform().position.x, cameraSpeed * Time.deltaTime);
        mPosition.y = yOffset;
        mPosition.z = zOffset;
        SetPosition();
    }
    void SetPosition()
    {
        GetComponent<Transform>().position = mPosition;
    }
    Vector3 GetPosition()
    {
        return GetComponent<Transform>().position;
    }
    public void CheckIfTargetInSight()
    {
        //Vector2 position = mTarget.GetTransform().position;
        
        //if (!mBounds.Contains(position))
        //{
            
            MoveCamera();
        //}
    }
}
