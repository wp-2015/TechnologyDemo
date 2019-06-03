using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

namespace WP.JobSystemDemo
{
    public class TestMono : MonoBehaviour
    {
        //private void Start()
        //{
        //    NativeArray<int> result = new NativeArray<int>(1, Allocator.TempJob);
        //    MyJobSystem0 job0 = new MyJobSystem0();
        //    job0.a = 0;
        //    job0.b = 1;
        //    job0.result = result;
        //    JobHandle handle = job0.Schedule();
        //    handle.Complete();
        //    Debug.Log(result[0]);
        //    result.Dispose();
        //}

        //private void Start()
        //{
        //    //NativeArray<JobHandle> handles = new NativeArray<JobHandle>(1, Allocator.Temp);

        //    NativeArray<int> result0 = new NativeArray<int>(1, Allocator.TempJob);
        //    NativeArray<int> result1 = new NativeArray<int>(1, Allocator.TempJob);

        //    int timeBase = TimeHelper.GetCurrentMillisecond();//记录当前时间

        //    //Job0
        //    MyJobSystem0 job0 = new MyJobSystem0();
        //    job0.a = 0;
        //    job0.b = 1;
        //    job0.result = result0;
        //    var handle0 = job0.Schedule();
        //    //Job1
        //    MyJobSystem1 job1 = new MyJobSystem1();
        //    job1.a = 100;
        //    job1.result = result1;
        //    var handle1 = job1.Schedule();//job1.Schedule(JobHandle.CombineDependencies(handles));

        //    handle0.Complete();
        //    handle1.Complete();

        //    Debug.Log("Spend Time : " + (TimeHelper.GetCurrentMillisecond() - timeBase));
        //    result0.Dispose();
        //    result1.Dispose();

        //    //handles.Dispose();
        //}

        private void Start()
        {
            NativeArray<int> result0 = new NativeArray<int>(1, Allocator.TempJob);

            int timeBase = TimeHelper.GetCurrentMillisecond();//记录当前时间

            //Job0
            MyJobSystem0 job0 = new MyJobSystem0();
            job0.a = 0;
            job0.b = 1;
            job0.result = result0;
            var handle0 = job0.Schedule();
            //Job1
            MyJobSystem1 job1 = new MyJobSystem1();
            job1.a = 100;
            job1.result = result0;
            var handle1 = job1.Schedule(handle0);

            handle0.Complete();
            handle1.Complete();

            Debug.Log("Spend Time : " + (TimeHelper.GetCurrentMillisecond() - timeBase));
            result0.Dispose();
        }
    }
}