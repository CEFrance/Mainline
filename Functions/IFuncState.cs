using System.Collections.Generic;

namespace Functions
{
    public interface IFuncState
    {
        int EAddress { get; set; }
        List<IFunc> Functions { get; set; }
    }
}