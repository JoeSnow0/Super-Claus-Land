using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameController mGameController;
    private Vector3 mPosition;
    [Header("Camera Target")]
    [SerializeField] private Entity mTarget;
    [Header("Camera Speed")]
    [Range(0f, 30f)]
    [SerializeField] private float mCameraSpeed;
    //Camera Offset
    [Header("Camera Offset")]
    [SerializeField] private float zOffset = 10;
    [SerializeField] private float yOffset = 6;

    Camera mCamera;
    int mHorizontalBounds;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void InitializeCamera(GameController controller, Entity target)
    {
        mGameController = controller;
        SetTarget(target);
        MoveCamera();
    }
    private void SetTarget(Entity target)
    {
        mTarget = target;
    }
    private void MoveCamera()
    {
        mPosition.x = Mathf.Lerp(GetPosition().x, mTarget.GetTransform().position.x, mCameraSpeed * Time.deltaTime);
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
        
        if (transform.position.x < mTarget.transform.position.x)
        {
            
            MoveCamera();
        }
    }
}
