using System;
using System.Threading;

namespace Snippets.Threading.Actions
{
    /// <summary>
    ///     Represents an action which can be started and then waited on from another thread.  The result of the
    ///     action is stored directly within this class and not returned when the action is initiated.
    ///     If using .Net 4 use the task parallel library, this is useful for older versions of .Net
    /// </summary>
    public abstract class ActionBase
    {
        private readonly object _lockObject = new object();
        private readonly ManualResetEvent _requestCompleteEvent = new ManualResetEvent(false);
        private ActionStatus _status;

        public Exception Exception { get; private set; }

        public bool Complete
        {
            get { return _status == ActionStatus.Failed || _status == ActionStatus.Successful; }
        }

        public bool Failed
        {
            get { return Complete && _status == ActionStatus.Failed; }
        }

        public bool Successful
        {
            get { return Complete && _status == ActionStatus.Successful; }
        }

        /// <summary>
        ///     Executes this action this may return immediately or block the current thread, this
        ///     choice is implementation specific.  If you need the action the have completed
        ///     before continuing use <see cref="WaitToComplete" />
        /// </summary>
        public void Execute()
        {
            lock (_lockObject)
            {
                if (_status != ActionStatus.Pending)
                {
                    return;
                }
                _status = ActionStatus.Initiated;
            }

            try
            {
                InternalExecute();
            }
            catch (Exception e)
            {
                MarkFailed(e);
            }
        }

        protected abstract void InternalExecute();

        public bool WaitToComplete(TimeSpan maxWaitTime)
        {
            return _requestCompleteEvent.WaitOne(maxWaitTime);
        }

        protected void MarkFailed(Exception ex = null)
        {
            Exception = ex;
            lock (_lockObject)
            {
                _status = ActionStatus.Failed;
            }
        }

        protected void MarkSuccesful()
        {
            lock (_lockObject)
            {
                _status = ActionStatus.Successful;
            }
        }

        protected enum ActionStatus
        {
            Pending,
            Initiated,
            Successful,
            Failed
        }
    }
}