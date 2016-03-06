using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

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

    interface Interface9<T1, T2, T3>
    {
    }

    interface Interface10<T1, T2> : Interface9<T1, T2, int>
    {
    }

    interface Interface11<T> : Interface9<T, int, T>
    {
    }

    #endregion

    [TestClass]
    public class SystemTypeToLogicalTypeTest
    {
        private TLogicalType GetTestType<TType, TLogicalType>() where TLogicalType : DotNetType
            => GetTestType<TLogicalType>(typeof(TType));

        private TLogicalType GetTestType<TLogicalType>(Type type) where TLogicalType : DotNetType
        {
            var logicalType = type.ToLogicalType();
            Assert.IsInstanceOfType(logicalType, typeof(TLogicalType));
            return (TLogicalType)logicalType;
        }
        
        [TestMethod]
        public void BaseTypeTest()
        {
            var boolType = GetTestType<bool, StructType>();
            var charType = GetTestType<char, StructType>();
            var shortType = GetTestType<short, StructType>();
            var intType = GetTestType<int, StructType>();
            var longType = GetTestType<long, StructType>();
            var floatType = GetTestType<float, StructType>();
            var doubleType = GetTestType<double, StructType>();
            var stringType = GetTestType<string, ClassType>();
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
            var interfaceTypeWithoutArgs = GetTestType<InterfaceType>(typeof(Interface6<>));
            Interface6Test(interfaceTypeWithoutArgs);
        }
        private void Interface6Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface6<object>), interfaceType.Name);

            var t = interfaceType.ParameterTypes.First();
            Assert.AreEqual(typeof(Interface6<>).GetGenericArguments().First().Name, t.Name);

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }
        private void Interface6Test<T>(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface6<T>), interfaceType.Name);

            var t = interfaceType.ParameterTypes.First();
            Assert.AreEqual(typeof(Interface6<T>).GetGenericArguments().First().Name, t.Name);

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        [TestMethod]
        public void Interface7ToLogicalTypeTest()
        {
            var interfaceType = GetTestType<InterfaceType>(typeof(Interface7<>));
            Interface7Test(interfaceType);
        }
        private void Interface7Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface7<object>), interfaceType.Name);

            var t = interfaceType.ParameterTypes.First();
            Assert.AreEqual(typeof(Interface7<>).GetGenericArguments().First().Name, t.Name);
            Interface6Test(interfaceType.BaseInterfaces.First());
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

        [TestMethod]
        public void Interface9ToLogicalTypeTest()
        {
            Interface9Test(GetTestType<InterfaceType>(typeof(Interface9<,,>)));
            Interface9Test<int, string, Interface6<bool>>(GetTestType<InterfaceType>(typeof(Interface9<int, string, Interface6<bool>>)));
        }

        private void Interface9Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface9<object, object, object>), interfaceType.Name);

            var sourceNames = typeof(Interface9<,,>).GetTypeInfo().
                GenericTypeParameters.Select(x => x.ToLogicalType().Name).ToArray();
            var distNames = interfaceType.ParameterTypes.Select(x => x.Name).ToArray();
            for (var i = 0; i < sourceNames.Length; i++)
            {
                Assert.AreEqual(sourceNames[i], distNames[i]);
            }

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }
        private void Interface9Test<T1, T2, T3>(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface9<T1, T2, T3>), interfaceType.Name);

            var sourceNames = typeof(Interface9<T1, T2, T3>).
                GenericTypeArguments.Select(x => x.ToLogicalType().Name).ToArray();
            var distNames = interfaceType.ParameterTypes.Select(x => x.Name).ToArray();
            for (var i = 0; i < sourceNames.Length; i++)
            {
                Assert.AreEqual(sourceNames[i], distNames[i]);
            }

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        [TestMethod]
        public void Interface10ToLogicalTypeTest()
        {
            Interface10Test(GetTestType<InterfaceType>(typeof(Interface10<,>)));
            Interface10Test<int, string>(GetTestType<InterfaceType>(typeof(Interface10<int, string>)));
        }

        private void Interface10Test(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface10<object, object>), interfaceType.Name);

            var sourceNames = typeof(Interface10<,>).GetTypeInfo().
                GenericTypeParameters.Select(x => x.ToLogicalType().Name).ToArray();
            var distNames = interfaceType.ParameterTypes.Select(x => x.Name).ToArray();
            for (var i = 0; i < sourceNames.Length; i++)
            {
                Assert.AreEqual(sourceNames[i], distNames[i]);
            }

            Interface9Test(interfaceType.BaseInterfaces.First());
        }
        private void Interface10Test<T1, T2>(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(Interface10<T1, T2>), interfaceType.Name);

            var sourceNames = typeof(Interface10<T1, T2>).
                GenericTypeArguments.Select(x => x.ToLogicalType().Name).ToArray();
            var distNames = interfaceType.ParameterTypes.Select(x => x.Name).ToArray();
            for (var i = 0; i < sourceNames.Length; i++)
            {
                Assert.AreEqual(sourceNames[i], distNames[i]);
            }

            Interface9Test<T1, T2, int>(interfaceType.BaseInterfaces.First());
        }
    }
}
