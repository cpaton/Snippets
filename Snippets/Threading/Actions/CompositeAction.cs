using System;

namespace Snippets.Threading.Actions
{
    /// <summary>
    /// Runs an action, and if that is successful runs a second action
    /// </summary>
    public class CompositeAction : ActionBase
    {
        private readonly ActionBase _action;
        private readonly Func<ActionBase> _continuation;

        public CompositeAction(ActionBase action, Func<ActionBase> continuation)
        {
            _action = action;
            _continuation = continuation;
        }

        protected override void InternalExecute()
        {
            _action.Execute();
            _action.WaitToComplete(TimeSpan.FromSeconds(30));

            if (_action.Successful)
            {
                var continuationAction = _continuation();
                continuationAction.Execute();

                if (continuationAction.Successful)
                {
                    MarkSuccesful();
                }
                else
                {
                    MarkFailed(continuationAction.Exception);
                }
            }
            else
            {
                MarkFailed(_action.Exception);
            }
        }
    }
}