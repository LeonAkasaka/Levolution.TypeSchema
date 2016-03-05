using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConceptualType
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IConceptualAnnotation> IAnnotations { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IConceptualProperty> Properties { get; }
    }
}
