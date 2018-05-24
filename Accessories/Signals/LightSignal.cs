using System;
using System.Collections.Generic;

namespace Accessories.Signals
{
    [Serializable]
    public class LightSignal : Signal
    {
        public LightSignal()
        {
            Aspects = new List<SignalColour>();
            Aspects.Add(SignalColour.Red);
            Aspects.Add(SignalColour.Green);
        }
    }
}