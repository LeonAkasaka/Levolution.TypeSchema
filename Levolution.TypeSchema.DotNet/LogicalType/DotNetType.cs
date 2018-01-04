using Levolution.TypeSchema.LogicalType;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Levolution.TypeSchema.LogicalType.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public class DotNetType : ILogicalType
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<DotNetMember> Members { get; } = new ObservableCollection<DotNetMember>();

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<ILogicalMember> ILogicalType.Members => Members;

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
        public DotNetType(string name)
        {
            Name = name;
        }
    }
}
