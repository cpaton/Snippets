namespace Snippets.Specification
{
    /// <summary>
    /// Inverts the conditions that satisfy a given rule
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !_specification.IsSatisfiedBy(candidate);
        }
    }
}
