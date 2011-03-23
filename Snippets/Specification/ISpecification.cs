namespace Snippets.Specification
{
    /// <summary>
    /// Represents a rule that can be applied to an object
    /// </summary>
    /// <typeparam name="T">Type of object that the rule applies to</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Checks an instance of a business object to see if it satisifies the rule
        /// </summary>
        /// <param name="candidate">Object to check against the rule</param>
        /// <returns>True if the candidate satisfies the rule false otherwise</returns>
        bool IsSatisfiedBy(T candidate);
    }
}