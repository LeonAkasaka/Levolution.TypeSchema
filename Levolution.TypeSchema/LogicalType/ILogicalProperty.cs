namespace Levolution.TypeSchema.LogicalType
{
    /// <summary>
    /// Represents a logical property of <see cref="ILogicalType"/>.
    /// </summary>
    public interface ILogicalProperty : ILogicalMember
    {
        /// <summary>
        /// Gets the property type.
        /// </summary>
        ILogicalType PropertyType { get; }
    }
}