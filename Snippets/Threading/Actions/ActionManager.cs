using System.Collections.Generic;

namespace Snippets.Threading.Actions
{
    /// <summary>
    ///     Sample class fof managing the execution of actions and allowing you to retrieve them later to get their results
    /// </summary>
    public class ActionManager
    {
        private readonly Dictionary<object, ActionBase> _requests = new Dictionary<object, ActionBase>();

        public void SendRequestAsync(object key)
        {
            if (_requests.ContainsKey(key))
            {
                return;
            }

            var firstAction = new SampleAction("First");
            ActionBase twoStepAction = firstAction.ContinueWith(() => new SampleAction("Second"));
            _requests[key] = twoStepAction;
            twoStepAction.ExecuteAsync();
        }
    }
}