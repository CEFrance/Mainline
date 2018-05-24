using System.Collections.Generic;
using Functions;

public interface IFunctionState
{
    int EAddress { get; set; }
    List<IFunction> Functions { get; set; }
}