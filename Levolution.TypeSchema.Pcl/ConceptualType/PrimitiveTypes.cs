namespace Levolution.TypeSchema.ConceptualType
{
    /// <summary>
    /// 
    /// </summary>
    public static class PrimitiveTypes
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly IPrimitiveType BooleanType = new BooleanType();

        /// <summary>
        /// 
        /// </summary>
        public static readonly ICharType CharType = new CharType("Char");

        /// <summary>
        /// 
        /// </summary>
        public static readonly IIntegerType Int8Type = new IntegerType("Int8", 1, IntegerSign.Signed);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IIntegerType UInt8Type = new IntegerType("UInt8", 1, IntegerSign.Unsigned);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IIntegerType Int16Type = new IntegerType("Int16", 2, IntegerSign.Signed);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IIntegerType UInt16Type = new IntegerType("UInt16", 2, IntegerSign.Unsigned);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IIntegerType Int32Type = new IntegerType("Int32",4, IntegerSign.Signed);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IIntegerType UInt32Type = new IntegerType("UInt32",4, IntegerSign.Unsigned);

        /// <summary>
        /// /
        /// </summary>
        public static readonly IIntegerType Int64Type = new IntegerType("Int64", 8, IntegerSign.Signed);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IIntegerType UInt64Type = new IntegerType("UInt64", 8, IntegerSign.Unsigned);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IFloatingPointType SingleType = new FloatingPointType("Single", 4);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IFloatingPointType DoubleType = new FloatingPointType("Double", 8);

        /// <summary>
        /// 
        /// </summary>
        public static readonly IStringType StringType = new StringType("String", (CharType)CharType);
    }
}
