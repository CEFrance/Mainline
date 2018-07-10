using System;
using System.Collections.Generic;

namespace Functions
{
    public class EFunctions
    {
        public ushort EAddress { get; set; }
        public bool HasSound { get; set; }
        public List<Func> Function { get; }

        public EFunctions()
        {
            HasSound = false;
            Function = new List<Func>();
        }
    }
}
