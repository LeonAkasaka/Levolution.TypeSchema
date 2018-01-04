using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Levolution.Data.Name;

namespace Levolution.TypeSchema.ConceptualType.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class ConceptualType : IConceptualType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ConceptualAnnotation> Annotations { get; }
        IEnumerable<IConceptualAnnotation> IConceptualType.Annotations => Annotations;

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ConceptualProperty> Properties { get; }
        IEnumerable<IConceptualProperty> IConceptualType.Properties => Properties;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anntations"></param>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        public ConceptualType(IEnumerable<ConceptualAnnotation> annotations, string name, IEnumerable<ConceptualProperty> properties)
        {
            Annotations = annotations;
            Name = name;
            Properties = properties;
        }
    }
}
