using System;

namespace Snippets.Threading.Actions
{
    public class SampleAction : ActionBase
    {
        private readonly string _name;

        public SampleAction(string name)
        {
            _name = name;
        }

        protected override void InternalExecute()
        {
            var service = new SampleService();
            service.TakeSomeTime(_name, TimeSpan.FromSeconds(5), MarkSuccesful);
        }
    }
}