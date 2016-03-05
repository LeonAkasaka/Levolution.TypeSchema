using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
