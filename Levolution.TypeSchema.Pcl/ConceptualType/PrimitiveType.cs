using System.Collections.Generic;
using System.Linq;

namespace Levolution.TypeSchema.ConceptualType
{
    class PrimitiveType : IPrimitiveType
    {
        public string Description => string.Empty;

        public string Name { get; private set; }

        public virtual IEnumerable<IConceptualAnnotation> IAnnotations => Enumerable.Empty<IConceptualAnnotation>();

        public IEnumerable<IConceptualProperty> Properties => Enumerable.Empty<IConceptualProperty>();

        public PrimitiveType(string name) { Name = name; }
    }

    class BooleanType : PrimitiveType { public BooleanType() : base("Boolean") { } }

    class CharType : PrimitiveType, ICharType
    {
        public int? Size { get; }

        public CharType(string name, int? size = null) : base(name)
        {
            Size = size;
        }
    }

    class StringType : PrimitiveType, IStringType
    {
        public CharType CharType { get; }

        ICharType IStringType.CharType => CharType;

        public StringType(string name, CharType charType) : base(name)
        {
            CharType = charType;
        }
    }

    class IntegerType : PrimitiveType, IIntegerType
    {
        public IntegerSign Sign { get; private set; }

        public int Size { get; private set; }

        public IntegerType(string name, int size, IntegerSign sign) : base(name)
        {
            Size = size;
            Sign = sign;
        }
    }

    class NumberType : PrimitiveType, INumberType
    {
        public int Size { get; private set; }

        public NumberType(string name, int size) : base(name)
        {
            Size = size;
        }
    }

    class ArrayType : PrimitiveType, IArrayType
    {
        public IConceptualType ElementType { get; }

        public int Rank { get; }

        public ArrayType(string name, IConceptualType elementType, int rank = 1) : base(name)
        {
            ElementType = elementType;
            Rank = rank;
        }
    }
}
