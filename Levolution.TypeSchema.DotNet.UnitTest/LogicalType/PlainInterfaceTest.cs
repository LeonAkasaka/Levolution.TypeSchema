using Levolution.TypeSchema.LogicalType.DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Levolution.TypeSchema.DotNet.UnitTest.LogicalType
{
    interface IPlainInterface { }

    interface IAltPlainInterface { }

    [TestClass]
    public class PlainInterfaceTest : LogicalTypeTest
    {
        [TestMethod]
        public void TestPlainInterface()
        {
            var plainInterfaceType = CreateLogicalType<IPlainInterface, InterfaceType>();
            IsPlainInterface(plainInterfaceType);
            
            var altPlainInterfaceItype = CreateLogicalType<IAltPlainInterface, InterfaceType>();
            IsAltPlainInterface(altPlainInterfaceItype);
        }

        public static void IsPlainInterface(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(IPlainInterface), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());
            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        public static void IsAltPlainInterface(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(IAltPlainInterface), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());
            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }
    }
}
