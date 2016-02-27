using System;
using System.Linq;
using System.Reflection;
using Levolution.Core.Types;
using System.Collections.Generic;

namespace Levolution.TypeSchema.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DotNetType ToLogicalType(this Type type)
            => type.GetTypeInfo().ToLogicalType();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static DotNetType ToLogicalType(this TypeInfo typeInfo)
        {
            var logicalType = typeInfo.IsClass ? CreateClassType(typeInfo)
                : typeInfo.IsGenericParameter ? CreateParameterType(typeInfo)
                : typeInfo.IsInterface ? CreateInterfaceType(typeInfo)
                : (DotNetType)CreateStructType(typeInfo);
            return logicalType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static DotNetMember ToLogicalMember(this MemberInfo memberInfo)
        {
            var p = memberInfo as PropertyInfo;
            if (p != null) { return p.ToLogicalMember(); }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static DotNetProperty ToLogicalMember(this PropertyInfo memberInfo)
        {
            var logicalType = memberInfo.DeclaringType.ToLogicalType();
            return new DotNetProperty(memberInfo.Name, logicalType);
        }

        private static ClassType CreateClassType(TypeInfo typeInfo)
        {
            var parameterTypes = GetParameterTypes(typeInfo);
            var baseType = GetBaseType(typeInfo);
            var interfaceTypes = GetImplementedInterfaceTypes(typeInfo);

            var logicalType = new ClassType(typeInfo.GetNameWithoutArity(), parameterTypes, baseType, interfaceTypes);
            foreach (var member in GetMembers(typeInfo))
            {
                logicalType.Members.Add(member);
            }

            return logicalType;
        }

        private static IEnumerable<DotNetMember> GetMembers(TypeInfo typeInfo)
            => typeInfo.DeclaredMembers.Select(x => x.ToLogicalMember());

        private static InterfaceType CreateInterfaceType(TypeInfo typeInfo)
        {
            var parameterTypes = GetParameterTypes(typeInfo);
            var interfaceTypes = GetImplementedInterfaceTypes(typeInfo);
            var logicalType = new InterfaceType(typeInfo.GetNameWithoutArity(), parameterTypes, interfaceTypes);
            return logicalType;
        }

        private static ParameterType CreateParameterType(TypeInfo typeInfo)
        {
            var logicalType = new ParameterType(typeInfo.GetNameWithoutArity());
            return logicalType;
        }

        private static StructType CreateStructType(TypeInfo typeInfo)
        {
            var parameterTypes = GetParameterTypes(typeInfo);
            var logicalType = new StructType(typeInfo.GetNameWithoutArity(), parameterTypes);
            return logicalType;
        }

        private static IEnumerable<InterfaceType> GetImplementedInterfaceTypes(TypeInfo typeInfo)
            => typeInfo.GetAllImplementedInterfaces().Select(x => CreateInterfaceType(x.GetTypeInfo()));

        private static ClassType GetBaseType(TypeInfo typeInfo)
            => typeInfo.BaseType != null ? CreateClassType(typeInfo.BaseType.GetTypeInfo()) : null;

        private static IEnumerable<ParameterType> GetParameterTypes(TypeInfo typeInfo)
            => typeInfo.GenericTypeArguments.Concat(typeInfo.GenericTypeParameters).Select(x => CreateParameterType(x.GetTypeInfo()));
    }
}
