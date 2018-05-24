using System;

namespace Accessories.Signals
{
    [Serializable]
    public class FourLightSignal : ThreeLightSignal
    {
        public FourLightSignal()
        {
            Aspects.Add(SignalColour.DoubleYellow);
        }
    }
}