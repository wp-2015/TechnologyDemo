using Unity.Collections;
using Unity.Jobs;

namespace WP.JobSystemDemo
{
    public struct MyJobSystem0 : IJob
    {
        public int a;
        public int b;
        public NativeArray<int> result;

        public void Execute()
        {
            var index = 0;
            for(int i = 0; i < 1000000; i++)
            {
                index++;
            }
            result[0] = a + b;
            //UnityEngine.Debug.Log("MyJobSystem0 result[0] : " + result[0]);
        }
    }
}
