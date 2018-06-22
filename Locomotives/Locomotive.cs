using System;
using Functions;

namespace Locomotives
{
    public class Locomotive : ILocomotive
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Class { get; set; }
        public string Owner { get; set; }
        public string Configuration { get; set; }
        public LocomotiveType Type { get; set; }
        public LocomotiveRole Role { get; set; }
        public EFunctions Functions { get; set; }
    }
}