using System;
using System.Threading;

namespace Snippets.Threading.Actions
{
    public class SampleService
    {
        public void TakeSomeTime(string name, TimeSpan actionTime, Action callback)
        {
            ThreadPool.QueueUserWorkItem(_ =>
                {
                    Thread.Sleep(actionTime);
                    Console.WriteLine("Running action {0}", name);
                    callback();
                });
        }
    }
}