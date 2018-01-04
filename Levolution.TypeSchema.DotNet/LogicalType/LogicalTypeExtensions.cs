using Levolution.TypeSchema.LogicalType;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Levolution.TypeSchema.LogicalType.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class LogicalTypeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logicalType"></param>
        /// <returns></returns>
        public static string ToCSharp(this ILogicalType logicalType)
            => (logicalType as DotNetType)?.ToCSharp();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logicalType"></param>
        /// <returns></returns>
        public static string ToCSharp(this DotNetType logicalType)
            => (logicalType as ClassType)?.ToCSharp() ??
                (logicalType as InterfaceType)?.ToCSharp() ??
                (logicalType as StructType)?.ToCSharp();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logicalType"></param>
        /// <returns></returns>
        public static string ToCSharp(this ClassType logicalType)
            => $@"public class {logicalType.Name}{ToTypeArguments(logicalType.ParameterTypes)} : {ToClassBase(logicalType.BaseType, logicalType.Interfaces)}
{{
{string.Join("\n", logicalType.Members.Select(x => x.ToCSharp()))}
}}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static string ToCSharp(this InterfaceType interfaceType)
            => $@"public interface {interfaceType.Name}{ToTypeArguments(interfaceType.ParameterTypes)} : {ToClassBase(null, interfaceType.BaseInterfaces)}
{{
{string.Join("\n", interfaceType.Members.Select(x => x.ToCSharp()))}
}}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="structType"></param>
        /// <returns></returns>
        public static string ToCSharp(this StructType structType)
            => $@"public struct {structType.Name}{ToTypeArguments(structType.ParameterTypes)} : {ToClassBase(null, structType.Interfaces)}
{{
{string.Join("\n", structType.Members.Select(x => x.ToCSharp()))}
}}";

        private static string ToClassBase(ClassType baseType, IEnumerable<InterfaceType> interfaces)
        {
            var str = new StringBuilder();
            if (baseType != null) { str.Append(baseType.Name); }

            str.Append(string.Join(",", interfaces.Select(x => x.Name)));
            return str.ToString();
        }

        private static string ToTypeArguments(IEnumerable<ParameterType> parameterTypes)
        {
            if (parameterTypes == null || !parameterTypes.Any()) { return ""; }
            return $"<{string.Join(",", parameterTypes.Select(x => x.Name))}>";
        }
    }
}
