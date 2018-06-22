using System;
using Functions;

namespace Locomotives
{
    public interface ILocomotive
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Number { get; set; }
        string Class { get; set; }
        string Owner { get; set; }
        string Configuration { get; set; }
        LocomotiveType Type { get; set; }
        LocomotiveRole Role { get; set; }
        EFunctions Functions { get; set; }
    }
}