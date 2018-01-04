namespace Levolution.TypeSchema.LogicalType
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogicalProperty : ILogicalMember
    {
        /// <summary>
        /// 
        /// </summary>
        ILogicalType PropertyType { get; }
    }
}