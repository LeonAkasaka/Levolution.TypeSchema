using Levolution.TypeSchema.LogicalType;

namespace Levolution.TypeSchema.LogicalType.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public class DotNetProperty : DotNetMember, ILogicalProperty
    {
        /// <summary>
        /// 
        /// </summary>
        public DotNetType PropertyType { get; }
        ILogicalType ILogicalProperty.PropertyType => PropertyType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DotNetProperty(string name, DotNetType declaredType) : base(name, declaredType)
        {
        }
    }
}
