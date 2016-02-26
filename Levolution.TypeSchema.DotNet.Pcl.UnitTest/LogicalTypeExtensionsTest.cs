using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Levolution.TypeSchema.DotNet.Pcl.UnitTest
{
    #region Types for logical types unit tests.

    interface Interface1
    {
    }

    interface Interface2
    {
    }

    interface Interface3 : Interface1
    {
    }

    interface Interface4 : Interface1, Interface2
    {
    }

    interface Interface5 : Interface3, Interface2
    {
    }

    interface Interface6<T>
    {
    }

    interface Interface7<T> : Interface6<T>
    {
    }

    interface Interface8 : Interface6<int>
    {
    }

    #endregion

    [TestClass]
    public class LogicalTypeExtensionsTest
    {
        private TLogicalType GetTestType<TType, TLogicalType>() where TLogicalType : DotNetType
        {
            var type = typeof(TType);
            var logicalType = type.ToLogicalType();

            Assert.IsInstanceOfType(logicalType, typeof(TLogicalType));

            return (TLogicalType)logicalType;
        }

        [TestMethod]
        public void Interface1ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface1, InterfaceType>();
            Interface1Test(interfaceType);
        }
        private void Interface1Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface1), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());
            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        [TestMethod]
        public void Interface2ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface2, InterfaceType>();
            Interface2Test(interfaceType);
        }
        private void Interface2Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface2), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());
            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        [TestMethod]
        public void Interface3ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface3, InterfaceType>();
            Interface3Test(interfaceType);

        }
        private void Interface3Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface3), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());
            Interface1Test(interfaceType.BaseInterfaces.First());
        }

        [TestMethod]
        public void Interface4ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface4, InterfaceType>();
            Interface4Test(interfaceType);

        }
        private void Interface4Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface4), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());

            Interface1Test(interfaceType.BaseInterfaces.Where(x => x.Name == nameof(Interface1)).First());
            Interface2Test(interfaceType.BaseInterfaces.Where(x => x.Name == nameof(Interface2)).First());
        }

        [TestMethod]
        public void Interface5ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface5, InterfaceType>();
            Interface5Test(interfaceType);

        }
        private void Interface5Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface5), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());

            Interface3Test(interfaceType.BaseInterfaces.Where(x => x.Name == nameof(Interface3)).First());
            Interface2Test(interfaceType.BaseInterfaces.Where(x => x.Name == nameof(Interface2)).First());
        }

        [TestMethod]
        public void Interface6ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface6<int>, InterfaceType>();
            Interface6Test<int>(interfaceType);
        }
        private void Interface6Test<T>(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface6<T>), interfaceType.Name);

            var t = interfaceType.ParameterTypes.First();
            Assert.AreEqual(typeof(Interface6<>).GetGenericArguments().First().Name, t);

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        [TestMethod]
        public void Interface7ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface7<int>, InterfaceType>();
            Interface7Test<int>(interfaceType);
        }
        private void Interface7Test<T>(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface7<T>), interfaceType.Name);

            var t = interfaceType.ParameterTypes.First();
            Assert.AreEqual(typeof(Interface7<>).GetGenericArguments().First().Name, t);
            Interface6Test<T>(interfaceType.BaseInterfaces.First());
        }

        [TestMethod]
        public void Interface8ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<Interface8, InterfaceType>();
            Interface8Test(interfaceType);
        }
        private void Interface8Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface8), interfaceType.Name);
            Assert.IsFalse(interfaceType.ParameterTypes.Any());

            Interface6Test<int>(interfaceType.BaseInterfaces.First());
        }
    }
}
