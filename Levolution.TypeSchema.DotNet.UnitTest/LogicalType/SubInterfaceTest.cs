using Levolution.TypeSchema.LogicalType.DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Levolution.TypeSchema.DotNet.UnitTest.LogicalType
{
    interface SubInterface : IPlainInterface { }

    interface SubInterfaceExtendsMultipleBaseInterfaces : IPlainInterface, IAltPlainInterface { }

    interface HierarchicalSubInterface : SubInterface { }

    [TestClass]
    public class SubInterfaceTest : LogicalTypeTest
    {
        [TestMethod]
        public void TestSubInterface()
        {
            var subInterfaceType = CreateLogicalType<SubInterface, InterfaceType>();
            IsSubInterface(subInterfaceType);
            
            var subInterfaceExtendsMultipleBaseInterfacesType = CreateLogicalType<SubInterfaceExtendsMultipleBaseInterfaces, InterfaceType>();
            IsSubInterfaceExtendsMultipleBaseInterfaces(subInterfaceExtendsMultipleBaseInterfacesType);

            var hierarchicalSubInterfaceType = CreateLogicalType<HierarchicalSubInterface, InterfaceType>();
            IsHierarchicalSubInterface(hierarchicalSubInterfaceType);
        }

        public void IsSubInterface(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(SubInterface), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());
            
            var baseInterfaces = interfaceType.BaseInterfaces.ToArray();
            Assert.AreEqual(baseInterfaces.Length, 1);
            PlainInterfaceTest.IsPlainInterface(baseInterfaces[0]);
        }

        public void IsSubInterfaceExtendsMultipleBaseInterfaces(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(SubInterfaceExtendsMultipleBaseInterfaces), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());

            var baseInterfaces = interfaceType.BaseInterfaces.ToArray();
            Assert.AreEqual(baseInterfaces.Length, 2);
            PlainInterfaceTest.IsPlainInterface(baseInterfaces[0]);
            PlainInterfaceTest.IsAltPlainInterface(baseInterfaces[1]);
        }

        public void IsHierarchicalSubInterface(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(HierarchicalSubInterface), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());

            var baseInterfaces = interfaceType.BaseInterfaces.ToArray();
            Assert.AreEqual(baseInterfaces.Length, 2);

            IsSubInterface(baseInterfaces[0]);
            PlainInterfaceTest.IsPlainInterface(baseInterfaces[1]);
        }
    }
}
