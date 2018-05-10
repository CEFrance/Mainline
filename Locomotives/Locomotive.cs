using System;
using Functions;

namespace Locomotives
{
    [Serializable]
    public abstract class Locomotive : ILocomotive
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Class { get; set; }
        public string Owner { get; set; }
        public string Configuration { get; set; }
        public LocomotiveRole Role { get; set; }
        public IEFunctions Functions { get; set; }
    }
}