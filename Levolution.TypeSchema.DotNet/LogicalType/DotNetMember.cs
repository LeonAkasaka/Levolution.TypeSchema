using Levolution.TypeSchema.LogicalType;

namespace Levolution.TypeSchema.LogicalType.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public class DotNetMember : ILogicalMember
    {
        /// <summary>
        /// 
        /// </summary>
        public DotNetType DeclaredType { get; }
        /// <summary>
        /// 
        /// </summary>
        ILogicalType ILogicalMember.DeclaredType => DeclaredType;

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DotNetMember(string name, DotNetType declaredType)
        {
            Name = name;
            DeclaredType = declaredType;
        }
    }
}