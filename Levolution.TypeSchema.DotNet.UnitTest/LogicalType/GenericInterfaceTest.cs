using Levolution.TypeSchema.LogicalType.DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace Levolution.TypeSchema.DotNet.UnitTest.LogicalType
{
    interface OneTypeParameterGenericInterface<T> { }

    interface TwoTypeParameterGenericInterface<T1, T2> { }

    [TestClass]
    public class GenericInterfaceTest : LogicalTypeTest
    {
        [TestMethod]
        public void TestGenericInterface()
        {
            var openedOneTypeParameterGenericInterfaceType = CreateLogicalType<InterfaceType>(typeof(OneTypeParameterGenericInterface<>)); // open gerenic
            IsOneTypeParameterGenericInterface(openedOneTypeParameterGenericInterfaceType);

            var closedOneTypeParameterGenericInterfaceType = CreateLogicalType<InterfaceType>(typeof(OneTypeParameterGenericInterface<int>)); // closed gerenic
            IsOneTypeParameterGenericInterface<int>(closedOneTypeParameterGenericInterfaceType);

            var openedTwoTypeParameterGenericInterfaceType = CreateLogicalType<InterfaceType>(typeof(TwoTypeParameterGenericInterface<,>)); // open gerenic
            IsTwoTypeParameterGenericInterface(openedTwoTypeParameterGenericInterfaceType);

            var closedTwoTypeParameterGenericInterfaceType = CreateLogicalType<InterfaceType>(typeof(TwoTypeParameterGenericInterface<int,string>)); // closed gerenic
            IsTwoTypeParameterGenericInterface<int, string>(closedTwoTypeParameterGenericInterfaceType);
        }

        private void IsOneTypeParameterGenericInterface(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(OneTypeParameterGenericInterface<object>), interfaceType.Name); // nameof... https://github.com/dotnet/csharplang/issues/702

            var parameterTypes = interfaceType.ParameterTypes.ToArray();
            Assert.AreEqual(parameterTypes.Length, 1);
            Assert.AreEqual(typeof(OneTypeParameterGenericInterface<>).GetGenericArguments().First().Name, parameterTypes[0].Name);

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        private void IsOneTypeParameterGenericInterface<T>(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(OneTypeParameterGenericInterface<T>), interfaceType.Name);

            var parameterTypes = interfaceType.ParameterTypes.ToArray();
            Assert.AreEqual(parameterTypes.Length, 1);
            Assert.AreEqual(typeof(T).Name, parameterTypes[0].Name);

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        private void IsTwoTypeParameterGenericInterface(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(TwoTypeParameterGenericInterface<object, object>), interfaceType.Name); // nameof... https://github.com/dotnet/csharplang/issues/702

            var parameterTypes = interfaceType.ParameterTypes.ToArray();
            Assert.AreEqual(parameterTypes.Length, 2);

            var sourceNames = typeof(TwoTypeParameterGenericInterface<,>).GetTypeInfo().GenericTypeParameters.Select(x => x.ToLogicalType().Name).ToArray();
            var distNames = interfaceType.ParameterTypes.Select(x => x.Name).ToArray();
            Assert.IsTrue(sourceNames.SequenceEqual(distNames));
            
            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }

        private void IsTwoTypeParameterGenericInterface<T1, T2>(InterfaceType interfaceType)
        {
            Assert.IsNotNull(interfaceType);
            Assert.AreEqual(nameof(TwoTypeParameterGenericInterface<object, object>), interfaceType.Name); // nameof... https://github.com/dotnet/csharplang/issues/702

            var parameterTypes = interfaceType.ParameterTypes.ToArray();
            Assert.AreEqual(parameterTypes.Length, 2);

            var sourceNames = new string[] { typeof(T1).Name, typeof(T2).Name };
            var distNames = interfaceType.ParameterTypes.Select(x => x.Name).ToArray();
            Assert.IsTrue(sourceNames.SequenceEqual(distNames));

            Assert.IsFalse(interfaceType.BaseInterfaces.Any());
        }
    }
}
