using System.Collections.Generic;
using System.Linq;

namespace Levolution.TypeSchema.ConceptualType
{
    using CType = Impl.ConceptualType;
    using CProperty = Impl.ConceptualProperty;
    using CAnntation = Impl.ConceptualAnnotation;

    /// <summary>
    /// 
    /// </summary>
    public static class TypeFactory
    {
        private static readonly IEnumerable<CAnntation> EmptyAnntations = Enumerable.Empty<CAnntation>();
        private static readonly IEnumerable<CProperty> EmptyProperties = Enumerable.Empty<CProperty>();

        #region ConceptualType

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CType ConceptualType(string name)
            => new CType(EmptyAnntations, name, Enumerable.Empty<CProperty>());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static CType ConceptualType(string name, IEnumerable<CProperty> properties)
            => new CType(EmptyAnntations, name, properties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anntations"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CType ConceptualType(IEnumerable<CAnntation> anntations, string name)
            => new CType(anntations, name, EmptyProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anntations"></param>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static CType ConceptualType(IEnumerable<CAnntation> anntations, string name, IEnumerable<CProperty> properties)
            => new CType(anntations, name, properties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anntations"></param>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static CType ConceptualType(IEnumerable<CAnntation> anntations, string name, params CProperty[] properties)
            => new CType(anntations, name, properties);

        #endregion

        #region ConceptualProperty

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CProperty ConceptualProperty(CType propertyType, string name)
            => new CProperty(EmptyAnntations, propertyType, name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="annotations"></param>
        /// <param name="propertyType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CProperty ConceptualProperty(IEnumerable<CAnntation> annotations, CType propertyType, string name)
            => new CProperty(annotations, propertyType, name);

        #endregion
    }
}
