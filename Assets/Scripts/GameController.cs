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
    private List<Entity> entityList = new List<Entity>();
    private List<Entity> oldEntityList = new List<Entity>();
    private List<Entity> newEntityList = new List<Entity>();
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
    private void LateUpdate()
    {
        AddNewEntities();
        UpdateEntityList();
        DeleteOldEntities();
    }
    public void AddEntity(Entity newEntity)
    {
        newEntityList.Add(newEntity);
    }
    public void RemoveEntity(Entity oldEntity)
    {
        oldEntityList.Add(oldEntity);
    }
    private void AddNewEntities()
    {
        if(newEntityList.Count != 0)
        {
            for (int i = 0; i < newEntityList.Count; i++)
            {
                entityList.Add(newEntityList[i]);
            }
            newEntityList.Clear();
        }
    }
    private void UpdateEntityList()
    {
        List<Entity> remainingEntities = new List<Entity>();
        for (int i = entityList.Count - 1; i > -1; i--)
        {
            for (int j = 0; j < oldEntityList.Count; j++)
            {
                if (i == j)
                { 
                    entityList.RemoveAt(i);
                }
            }
        }
    }
    private void DeleteOldEntities()
    {
        for (int i = oldEntityList.Count - 1; i > -1; i--)
        {
            oldEntityList[i].DestroySelf();
            oldEntityList.RemoveAt(i);
        }
    }
    void InitializeScene()
    {
        //CreatePlayer();
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
    
    /// <summary>
    /// Creates a new entity, adds it to the new entity list and initializes it.     
    /// </summary>
    /// <param name="entityprefab"></param>
    /// <param name="transform"></param>
    /// <returns></returns>
    public void CreateEntity(Entity entityprefab, Transform transform)
    {
        Entity newEntity = Instantiate(entityprefab, transform);
        newEntity.InitializeEntity(this);
        AddEntity(newEntity);
    }

    public Entity GetPlayerEntity()
    {
        return mPlayer;
    }
}
