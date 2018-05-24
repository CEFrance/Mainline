using System;

namespace Accessories.Signals
{
    [Serializable]
    public class ThreeLightSignal : LightSignal
    {
        public ThreeLightSignal()
        {
            Aspects.Add(SignalColour.Yellow);
        }
    }
}