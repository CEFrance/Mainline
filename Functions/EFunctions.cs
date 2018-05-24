using System;
using System.Collections.Generic;

namespace Functions
{
    [Serializable]
    public class EFunctions : IEFunctions
    {
        public ushort EAddress { get; set; }
        public bool HasSound { get; set; }
        public List<IFunction> Function { get; }

        public EFunctions()
        {
            HasSound = false;
            Function = new List<IFunction>();
        }
    }
}
