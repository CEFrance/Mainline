using System.Collections.Generic;
using Functions;

public class FuncState : IFunctionState
{
    public int EAddress { get; set; }
    public List<IFunction> Functions { get; set; }

    public FuncState()
    {
        Functions = new List<IFunction>();
    }
}