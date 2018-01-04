namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public interface IArrayType
    {
        /// <summary>
        /// 
        /// </summary>
        IConceptualType ElementType { get; }

        /// <summary>
        /// 
        /// </summary>
        int Rank { get; }
    }
}
