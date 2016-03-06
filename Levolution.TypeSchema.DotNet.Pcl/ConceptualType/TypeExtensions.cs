using System;
using System.Collections.Generic;
using System.Reflection;

namespace Levolution.TypeSchema.ConceptualType.DotNet
{
    public static class TypeExtensions
    {
        private static readonly Dictionary<TypeInfo, IConceptualType> _primitiveTypes = new Dictionary<TypeInfo, IConceptualType>()
        {
            { typeof(bool).GetTypeInfo(), PrimitiveTypes.BooleanType },
            { typeof(char).GetTypeInfo(), PrimitiveTypes.CharType },
            { typeof(sbyte).GetTypeInfo(), PrimitiveTypes.Int8Type },
            { typeof(byte).GetTypeInfo(), PrimitiveTypes.UInt8Type },
            { typeof(short).GetTypeInfo(), PrimitiveTypes.Int16Type },
            { typeof(ushort).GetTypeInfo(), PrimitiveTypes.UInt16Type },
            { typeof(int).GetTypeInfo(), PrimitiveTypes.Int32Type },
            { typeof(uint).GetTypeInfo(), PrimitiveTypes.UInt32Type },
            { typeof(long).GetTypeInfo(), PrimitiveTypes.Int64Type },
            { typeof(ulong).GetTypeInfo(), PrimitiveTypes.UInt64Type },
            { typeof(float).GetTypeInfo(), PrimitiveTypes.SingleType },
            { typeof(double).GetTypeInfo(), PrimitiveTypes.DoubleType },
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IConceptualType ToConceptualType(this Type type)
            => type.GetTypeInfo().ToConceptualType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static IConceptualType ToConceptualType(this TypeInfo typeInfo)
        {
            IConceptualType primitiveType;
            if (_primitiveTypes.TryGetValue(typeInfo, out primitiveType)) { return primitiveType; }
            
            // TODO: Create a conceptual type from Type.
            return null;
        }

    }
}
