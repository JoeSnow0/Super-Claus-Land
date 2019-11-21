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
        foreach(Entity entity0 in oldEntityList)
        {
            foreach(Entity entity1 in entityList)
            {
                if(entity0 == entity1)
                {
                    entityList.Remove(entity1);
                }
            }
        }
    }
    private void DeleteOldEntities()
    {
        if(oldEntityList.Count != 0)
        {
            foreach (Entity entity in oldEntityList)
            {
                Destroy(entity.gameObject);
            }
            oldEntityList.Clear();
        }
    }
    void InitializeScene()
    {
        //CreatePlayer();
        mPlayer = CreateEntity(mPlayerPrefab, gameObject.transform);
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
    public Entity CreateEntity(Entity entityprefab, Transform transform)
    {
        Entity newEntity = Instantiate(entityprefab, transform);
        newEntity.InitializeEntity(this);
        AddEntity(newEntity);
        return newEntity;
    }
}
