using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Levolution.TypeSchema.ConceptualType.DotNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<IConceptualType> ToConceptualTypes(this Assembly assembly)
            => assembly.DefinedTypes
                .Where(x => x.GetCustomAttribute<ConceptualTypeAttribute>() != null)
                .Select(x => x.ToConceptualType())
                .ToArray();
    }
}
