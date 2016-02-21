using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    public interface IConceptualType
    {
        string Name { get; }

        IEnumerable<IConceptualAnnotation> IAnnotations { get; set; }


        IEnumerable<IConceptualProperty> Properties { get; }
    }
}
