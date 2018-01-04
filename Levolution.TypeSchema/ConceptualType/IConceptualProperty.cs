using Levolution.Data.Name;
using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// Represents a conceptual propertyo of <see cref="IConceptualType"/>.
    /// </summary>
    public interface IConceptualProperty : INameable
    {
        /// <summary>
        /// Gets the Declaring type.
        /// </summary>
        IConceptualType DeclaringType { get; }

        /// <summary>
        /// Gets the property type.
        /// </summary>
        IConceptualType PropertyType { get; }

        /// <summary>
        /// Gets the annotations of this property.
        /// </summary>
        IEnumerable<IConceptualAnnotation> Annotations { get; }
    }
}
