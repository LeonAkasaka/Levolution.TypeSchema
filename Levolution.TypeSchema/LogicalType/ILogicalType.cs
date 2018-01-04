using Levolution.Data.Name;
using System.Collections.Generic;

namespace Levolution.TypeSchema.LogicalType
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogicalType : INameable
    {
        /// <summary>
        /// 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<ILogicalMember> Members { get; }
    }
}
