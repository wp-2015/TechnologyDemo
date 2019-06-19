using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;

namespace WP.ECSAndJobSystem
{
    //[AlwaysUpdateSystem]
    public class RotateSystem : JobComponentSystem
    {
        struct RotateJob : IJobForEach<Rotation, CustomRotate>
        {
            public float time;
            public void Execute(ref Rotation c0, ref CustomRotate c1)
            {
                Quaternion q = c0.Value;
                var ang = q.eulerAngles;
                ang.y = ang.y + c1.Speeed * time;
                c0.Value = Quaternion.Euler(ang);
            }
        }
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var rotateJob = new RotateJob { time = Time.deltaTime };
            return rotateJob.Schedule(this, inputDeps);
        }
    }
}