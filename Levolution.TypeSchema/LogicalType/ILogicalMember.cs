using Levolution.Data.Name;

namespace Levolution.TypeSchema.LogicalType
{
    /// <summary>
    /// Represents a member of <see cref="ILogicalType"/>.
    /// </summary>
    public interface ILogicalMember : INameable
    {
        /// <summary>
        /// Gets the description of this logical member.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the Declaring type.
        /// </summary>
        ILogicalType DeclaringType { get; }
    }
}