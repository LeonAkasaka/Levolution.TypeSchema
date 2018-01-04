using Levolution.TypeSchema.LogicalType.DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Levolution.TypeSchema.DotNet.UnitTest.LogicalType
{
    public class LogicalTypeTest
    {
        protected static TLogicalType CreateLogicalType<TType, TLogicalType>() where TLogicalType : DotNetType
            => CreateLogicalType<TLogicalType>(typeof(TType));

        protected static TLogicalType CreateLogicalType<TLogicalType>(Type type) where TLogicalType : DotNetType
        {
            var logicalType = type.ToLogicalType();
            Assert.IsInstanceOfType(logicalType, typeof(TLogicalType));
            return (TLogicalType)logicalType;
        }
    }
}
