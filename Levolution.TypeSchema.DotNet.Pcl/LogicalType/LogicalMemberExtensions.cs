namespace Levolution.TypeSchema.LogicalType.DotNet
{
    public static class LogicalMemberExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string ToCSharp(this DotNetMember member)
            => (member as DotNetProperty)?.ToCSharp() ?? null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string ToCSharp(this DotNetProperty property)
            => $@"public {property.PropertyType.Name} {property.Name} {{ get; set;}}";
    }
}
