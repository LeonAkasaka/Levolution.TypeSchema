using System.Collections.Generic;
using System.Linq;

namespace Levolution.TypeSchema.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassType : ReferenceType
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ParameterType> ParameterTypes { get; }

        /// <summary>
        /// 
        /// </summary>
        public ClassType BaseType { get; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<InterfaceType> Interfaces { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ClassType(string name) : this(name, Enumerable.Empty<ParameterType>()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterTypes"></param>
        public ClassType(string name, IEnumerable<ParameterType> parameterTypes) : this(name, parameterTypes, null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="baseType"></param>
        public ClassType(string name, ClassType baseType) : this(name, Enumerable.Empty<ParameterType>(), baseType) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="baseType"></param>
        public ClassType(string name, IEnumerable<ParameterType> parameterTypes, ClassType baseType) : this(name, parameterTypes, baseType, Enumerable.Empty<InterfaceType>()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="baseType"></param>
        /// <param name="interfaces"></param>
        public ClassType(string name, IEnumerable<ParameterType> parameterTypes, ClassType baseType, IEnumerable<InterfaceType> interfaces) : base(name)
        { 
            ParameterTypes = parameterTypes;
            BaseType = baseType;
            Interfaces = interfaces;
        }
    }
}
