using Levolution.Data.Name;
using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConceptualProperty : INameable
    {
        /// <summary>
        /// 
        /// </summary>
        IConceptualType DeclaringType { get; }

        /// <summary>
        /// 
        /// </summary>
        IConceptualType PropertyType { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IConceptualAnnotation> Annotations { get; }
    }
}
