using System.Collections.Generic;

namespace Functions
{
    public interface IEFunctions
    {
        ushort EAddress { get; set; }
        bool HasSound { get; set; }
        List<IFunction> Function { get; }
    }
}
