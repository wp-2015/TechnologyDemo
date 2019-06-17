using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

//先把System注释掉，测试打开就可以。
/*
namespace WP.JobSystemWithUnityDemo
{
    public class MyJobSystemWithUnitySystem : JobComponentSystem
    {
        public struct MyJobSystem : IJobForEachWithEntity<MyData> //IJob//
        {
            //public void Execute()
            //{
            //    UnityEngine.Debug.Log("MyJobSystemWithUnitySystem MyJobSystem Execute");
            //}

            public void Execute(Entity entity, int index, ref MyData c0)
            {
                UnityEngine.Debug.Log("MyJobSystemWithUnitySystem MyJobSystem Execute");
                //throw new System.NotImplementedException();
            }
        }
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            UnityEngine.Debug.Log("MyJobSystemWithUnitySystem OnUpdate");
            MyJobSystem job = new MyJobSystem();
            var handle = job.Schedule(this, inputDeps);
            ////var handle = job.Schedule();
            return handle;
        }
    }
}
*/