using Levolution.Data.Name;
using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// Represents a conceptual type.
    /// Conceptual type is independent of actual system type.
    /// This type model should not dependent on programming models, languages, runtime systems.
    /// </summary>
    public interface IConceptualType : INameable
    {
        /// <summary>
        /// Gets the annotations of this type.
        /// </summary>
        IEnumerable<IConceptualAnnotation> Annotations { get; }

        /// <summary>
        /// Gets the properties (The state contained by this type).
        /// </summary>
        IEnumerable<IConceptualProperty> Properties { get; }
    }
}
