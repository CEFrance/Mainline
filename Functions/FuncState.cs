using System.Collections.Generic;

namespace Functions
{
    public class FuncState
    {
        public int EAddress { get; set; }
        public List<Func> Functions { get; set; }

        public FuncState()
        {
            Functions = new List<Func>();
        }
    }
}