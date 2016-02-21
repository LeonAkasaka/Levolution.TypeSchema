using Levolution.Data.Name;

namespace Levolution.TypeSchema.LogicalType
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogicalMember : INameable
    {
        /// <summary>
        /// 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 
        /// </summary>
        ILogicalType DeclaredType { get; }
    }
}
