using System.Collections.Generic;
using Locomotives;

namespace RailwayControlCentre
{
    public interface ILocomotiveStateService
    {
        List<SpeedAndDirection> GetState(List<ILocomotive> locomotives);
        void UpdateState(SpeedAndDirection data);
    }
}