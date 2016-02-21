using System.Collections.Generic;
using System.Linq;

namespace Levolution.TypeSchema.DotNet.LogicalType
{
    /// <summary>
    /// 
    /// </summary>
    public class InterfaceType : ReferenceType
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ParameterType> ParameterTypes { get; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<InterfaceType> BaseInterfaces { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public InterfaceType(string name) : this(name, Enumerable.Empty<ParameterType>()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterTypes"></param>
        public InterfaceType(string name, IEnumerable<ParameterType> parameterTypes) : this(name, parameterTypes, Enumerable.Empty<InterfaceType>()) { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public InterfaceType(string name, IEnumerable<ParameterType> parameterTypes, IEnumerable<InterfaceType> baseInterfaces) : base(name)
        {
            ParameterTypes = parameterTypes;
            BaseInterfaces = baseInterfaces;
        }
    }
}
