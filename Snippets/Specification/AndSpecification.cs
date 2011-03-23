namespace Snippets.Specification
{
    /// <summary>
    /// Combines two specifications together so that the rule is satisified if both of the specifications are satisfied
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _lhs;
        private readonly ISpecification<T> _rhs;

        public AndSpecification(ISpecification<T> lhs, ISpecification<T> rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _lhs.IsSatisfiedBy(candidate) && _rhs.IsSatisfiedBy(candidate);
        }
    }
}
