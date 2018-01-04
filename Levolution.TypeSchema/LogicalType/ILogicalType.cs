using Levolution.Data.Name;
using System.Collections.Generic;

namespace Levolution.TypeSchema.LogicalType
{
    /// <summary>
    /// Represents a logical type.
    /// Logical type provide information with actual type (implemented type in runtime system).
    /// </summary>
    public interface ILogicalType : INameable
    {
        /// <summary>
        /// Gets the description of this logical type.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the members of type.
        /// </summary>
        IEnumerable<ILogicalMember> Members { get; }
    }
}
