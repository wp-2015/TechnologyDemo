using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace WP.ECSAndJobSystem
{

    [UpdateBefore(typeof(RotateSystem))]
    public class MoveSystem : JobComponentSystem
    {
        [RequireComponentTag(typeof(PerData))]
        struct CustomMoveJob : IJobForEach<Translation, CustomMove>
        {
            public float time;
            public void Execute(ref Translation pos, ref CustomMove c1)
            {
                pos.Value.z = pos.Value.z + c1.Speed * time;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var moveJob = new CustomMoveJob { time = Time.deltaTime };
            return moveJob.Schedule(this, inputDeps);
        }
    }
}