using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class MyEntitiesManager : MonoBehaviour
{
    public Button btnAdd;
    public Button btnDestory;

    EntityManager manager;
    public GameObject goTemplete;
    Entity entity;
    Entity entityInstantiate;
    private void Start()
    {
        btnAdd.onClick.AddListener(AddEntity);
        btnDestory.onClick.AddListener(DestoryEntity);

        manager = World.Active.EntityManager;
        entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(goTemplete, World.Active);
    }

    void AddEntity()
    {
        NativeArray<Entity> arr = manager.GetAllEntities();
        if (arr.Length > 0)
        {
            entityInstantiate = manager.Instantiate(entity);
            manager.AddComponent(entityInstantiate, typeof(MyData));
        }
        arr = manager.GetAllEntities();
        Debug.Log(arr.Length);
    }

    void DestoryEntity()
    {
        NativeArray<Entity> arr = manager.GetAllEntities(); ;
        if (arr.Length > 0)
        {
            arr = manager.GetAllEntities();
            manager.DestroyEntity(arr);
        }
        arr = manager.GetAllEntities();
        Debug.Log(arr.Length);
    }
}
