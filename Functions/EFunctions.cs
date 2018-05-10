using System;

namespace Functions
{
    [Serializable]
    public class EFunctions : IEFunctions
    {
        public ushort EAddress { get; set; }
        public bool HasSound { get; set; }

        public EFunctions()
        {
            HasSound = false;
        }
    }
}
