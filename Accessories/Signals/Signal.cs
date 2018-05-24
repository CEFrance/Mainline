using System;
using System.Collections.Generic;
using Functions;

namespace Accessories.Signals
{
    [Serializable]
    public abstract class Signal : ISignal
    {
        public Guid Id { get; set; }
        public List<SignalColour> Aspects { get; set; }
        public IEFunctions Functions { get; set; }
        public SignalColour State { get; set; }
    }
}