using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levolution.TypeSchema.LogicalType.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public class NullableType : ValueType
    {
        /// <summary>
        /// 
        /// </summary>
        public ValueType NonNullableValueType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public NullableType(string name, ValueType type) : base(name)
        {
            NonNullableValueType = type;
        }
    }
}
