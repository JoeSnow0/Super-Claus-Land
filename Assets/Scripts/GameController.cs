using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public Entity mPlayerPrefab;
    [SerializeField] public CameraFollow mCameraPrefab;
    [SerializeField] private Transform mStartPoint;
    private Entity mPlayer;
    private CameraFollow mCamera;
    // Start is called before the first frame update
    void Start()
    {
        InitializeScene();   
    }

    // Update is called once per frame
    void Update()
    {
        mCamera.CheckIfTargetInSight();
    }
    void InitializeScene()
    {
        CreatePlayer();
        CreateCamera();
    }
    void CreateCamera()
    {
        mCamera = Instantiate(mCameraPrefab, mStartPoint);
        mCamera.InitializeCamera(this, mPlayer);
    }
    void CreatePlayer()
    {
        mPlayer = Instantiate(mPlayerPrefab, mStartPoint);
        mPlayer.InitializeEntity(this);
    }

}
