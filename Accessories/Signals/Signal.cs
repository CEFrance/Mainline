using System;
using System.Collections.Generic;
using Functions;

namespace Accessories.Signals
{
    public class Signal : ISignal
    {
        public Guid Id { get; set; }
        public List<SignalColour> Aspects { get; set; }
        public EFunctions Functions { get; set; }
        public SignalColour State { get; set; }
    }
}