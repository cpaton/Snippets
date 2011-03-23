using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snippets.Specification
{
    public class NotNull : Specification<object>
    {
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate != null;
        }
    }

    public class Null : Specification<object>
    {
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate != null;
        }
    }

    public class SpecificationExample
    {
        public static void Example()
        {
            var tautology = new NotNull() & new Null();
        }
    }
}
