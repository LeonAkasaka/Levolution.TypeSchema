using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConceptualProperty
    {
        string Name { get; }

        IEnumerable<IConceptualAnnotation> Annotations { get; }
    }
}
