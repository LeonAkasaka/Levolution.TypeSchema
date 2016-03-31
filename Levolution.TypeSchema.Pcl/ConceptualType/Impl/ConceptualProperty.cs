using System.Collections.Generic;

namespace Levolution.TypeSchema.ConceptualType.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class ConceptualProperty : IConceptualProperty
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ConceptualAnnotation> Annotations { get; }
        IEnumerable<IConceptualAnnotation> IConceptualProperty.Annotations => Annotations;

        /// <summary>
        /// 
        /// </summary>
        public ConceptualType PropertyType { get; }
        IConceptualType IConceptualProperty.PropertyType => PropertyType;

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public ConceptualType DeclaringType { get; }
        IConceptualType IConceptualProperty.DeclaringType => DeclaringType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ConceptualProperty(IEnumerable<ConceptualAnnotation> anntations, ConceptualType propertyType, string name)
        {
            Annotations = Annotations;
            PropertyType = propertyType;
            Name = name;
        }
    }
}