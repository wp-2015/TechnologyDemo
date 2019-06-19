using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace WP.ECSAndJobSystem
{
    public class CustomEntityManager : MonoBehaviour
    {
        public GameObject goTemplete;
        public int max = 1;
        public int intervalDis = 2;
        public Transform tfStartPos;

        EntityManager manager;
        Entity entityTemplete;
        private void Start()
        {
            manager = World.Active.EntityManager;
            entityTemplete = GameObjectConversionUtility.ConvertGameObjectHierarchy(goTemplete, World.Active);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.H))
            {
                MakeCubes(tfStartPos.position);
            }
            else if(Input.GetKeyDown(KeyCode.J))
            {
                DebugCubes();
            }
        }

        void MakeCubes(Vector3 sorPos)
        {
            int index = 0;
            NativeArray<Entity> bullets = new NativeArray<Entity>(max * max, Allocator.TempJob);
            manager.Instantiate(entityTemplete, bullets);
            
            Vector3 pos = sorPos;
            for (int i = 0; i < max; i++)
            {
                pos.x = sorPos.x + i * intervalDis;
                for (int j = 0; j < max; j++)
                {
                    pos.y = sorPos.y + j * intervalDis;
                    manager.SetComponentData(bullets[index], new Translation { Value = pos });
                    manager.AddComponentData(bullets[index], new PerData { });
                    //manager.AddComponentData(bullets[index], new CustomRotate { Speeed = 100.0f });
                    index++;
                }
            }
            bullets.Dispose();
        }

        void DebugCubes()
        {
            var entities = manager.GetAllEntities();
            Debug.Log(entities.Length);
            for (int i = 0; i < entities.Length; i++)
            {
                var tl = manager.GetComponentData<Translation>(entities[i]);
                Debug.Log(tl.Value);
            }
        }
    }
}