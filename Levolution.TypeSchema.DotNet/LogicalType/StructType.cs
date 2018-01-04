using System.Collections.Generic;
using System.Linq;

namespace Levolution.TypeSchema.LogicalType.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public class StructType : ValueType
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ParameterType> ParameterTypes { get; }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<InterfaceType> Interfaces { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public StructType(string name) : this(name, Enumerable.Empty<ParameterType>())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterTypes"></param>
        public StructType(string name, IEnumerable<ParameterType> parameterTypes) : this(name, parameterTypes, Enumerable.Empty<InterfaceType>())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="interfaces"></param>
        public StructType(string name, IEnumerable<ParameterType> parameterTypes, IEnumerable<InterfaceType> interfaces) : base(name)
        {
            ParameterTypes = parameterTypes;
            Interfaces = interfaces;
        }
    }
}
