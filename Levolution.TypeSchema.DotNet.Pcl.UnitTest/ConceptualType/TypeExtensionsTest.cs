using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levolution.TypeSchema.ConceptualType.DotNet.Pcl.UnitTest
{
    [TestClass]
    public class TypeExtensionsTest
    {
        [ConceptualType]
        class A
        {
            [ConceptualProperty]
            public int Field1;

            [ConceptualProperty]
            public string Field2;
        }


        [TestMethod]
        public void PrimitiveTypeTest()
        {
            Assert.AreEqual(PrimitiveTypes.BooleanType, typeof(bool).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.CharType, typeof(char).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.Int8Type, typeof(sbyte).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.UInt8Type, typeof(byte).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.Int16Type, typeof(short).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.UInt16Type, typeof(ushort).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.Int32Type, typeof(int).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.UInt32Type, typeof(uint).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.Int64Type, typeof(long).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.UInt64Type, typeof(ulong).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.SingleType, typeof(float).ToConceptualType());
            Assert.AreEqual(PrimitiveTypes.DoubleType, typeof(double).ToConceptualType());
        }
    }
}
