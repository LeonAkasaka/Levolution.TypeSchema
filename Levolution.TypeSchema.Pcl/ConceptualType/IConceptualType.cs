using Levolution.Data.Name;
using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConceptualType : INameable
    {
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
