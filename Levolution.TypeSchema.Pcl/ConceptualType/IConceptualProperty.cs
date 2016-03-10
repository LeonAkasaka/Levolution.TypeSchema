using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConceptualProperty
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
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IConceptualAnnotation> Annotations { get; }
    }
}
