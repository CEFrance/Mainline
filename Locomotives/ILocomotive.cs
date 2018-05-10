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
        LocomotiveRole Role { get; set; }
        IEFunctions Functions { get; set; }
    }
}