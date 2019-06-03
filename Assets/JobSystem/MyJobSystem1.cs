using Unity.Jobs;
using Unity.Collections;

namespace WP.JobSystemDemo
{
    public struct MyJobSystem1 : IJob
    {
        public int a;

        public NativeArray<int> result;

        public void Execute()
        {
            var index = 0;
            for (int i = 0; i < 1000000; i++)
            {
                index++;
            }
            result[0] = a + 1;
            //UnityEngine.Debug.Log("MyJobSystem1 result[0] : " + result[0]);
        }
    }
}