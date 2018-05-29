using System.Collections.Generic;

namespace Functions
{
    public class FuncState : IFuncState
    {
        public int EAddress { get; set; }
        public List<IFunc> Functions { get; set; }

        public FuncState()
        {
            Functions = new List<IFunc>();
        }
    }
}