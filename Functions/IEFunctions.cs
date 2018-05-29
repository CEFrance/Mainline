using System.Collections.Generic;

namespace Functions
{
    public interface IEFunctions
    {
        ushort EAddress { get; set; }
        bool HasSound { get; set; }
        List<IFunc> Function { get; }
    }
}
