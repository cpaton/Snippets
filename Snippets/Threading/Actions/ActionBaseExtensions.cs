using System;
using System.Threading;

namespace Snippets.Threading.Actions
{
    public static class ActionBaseExtensions
    {
        public static void ExecuteAsync(this ActionBase action)
        {
            ThreadPool.QueueUserWorkItem(_ => action.Execute());
        }

        public static ActionBase ContinueWith(this ActionBase action, Func<ActionBase> continuation)
        {
            return new CompositeAction(action, continuation);
        }
    }
}