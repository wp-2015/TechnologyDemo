using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace WP.ECSAndJobSystem
{
    public class MoveConversion : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new CustomMove { Speed = 1f });
            dstManager.AddComponentData(entity, new CustomRotate { Speeed = 100.0f });
        }
    }
}