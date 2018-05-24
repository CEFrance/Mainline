using System;
using System.Collections.Generic;
using Functions;

namespace Accessories.Signals
{
    public interface ISignal
    {
        Guid Id { get; set; }
        List<SignalColour> Aspects { get; set; }
        IEFunctions Functions { get; set; }
        SignalColour State { get; set; }
    }
}