namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIntegerType : IPrimitiveType
    {
        /// <summary>
        /// 
        /// </summary>
        int Size { get; }

        /// <summary>
        /// 
        /// </summary>
        IntegerSign Sign { get; }
    }
}
