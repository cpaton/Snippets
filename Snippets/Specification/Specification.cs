namespace Snippets.Specification
{
    /// <summary>
    /// Base class for business rules
    /// </summary>
    /// <typeparam name="T">Type of object that the rule applies to</typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        /// <summary>
        /// Checks an instance of a business object to see if it satisifies the rule
        /// </summary>
        /// <param name="candidate">Object to check against the rule</param>
        /// <returns>True if the candidate satisfies the rule false otherwise</returns>
        public abstract bool IsSatisfiedBy(T candidate);

        /// <summary>
        /// Combines this rule with another to create another rule that is only satisisfied if both rules are satisfied
        /// </summary>
        /// <param name="other">Rule to combine this rule with</param>
        /// <returns></returns>
        public Specification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public static Specification<T> operator&(Specification<T> lhs, Specification<T> rhs)
        {
            return new AndSpecification<T>(lhs, rhs);
        }

        public static Specification<T> operator |(Specification<T> lhs, Specification<T> rhs)
        {
            return new OrSpecification<T>(lhs, rhs);
        }

        public static Specification<T> operator !(Specification<T> lhs)
        {
            return new NotSpecification<T>(lhs);
        }

        /// <summary>
        /// Combines this rule with another to create another rule that is satisisfied if either rule is satisfied
        /// </summary>
        /// <param name="other">Rule to combine this rule with</param>
        /// <returns></returns>
        public Specification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}
