using System.Collections.Generic;
using System.Linq;

namespace Levolution.TypeSchema.DotNet
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
        /// <param name="name"></param>
        public StructType(string name) : this(name, Enumerable.Empty<ParameterType>())
        {
        }

        public StructType(string name, IEnumerable<ParameterType> parameterTypes) : base(name)
        {
            ParameterTypes = parameterTypes;
        }
    }
}
