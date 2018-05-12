using Locomotives;

namespace RailwayControlCentre
{
    public interface ILocomotiveStateService
    {
        SpeedAndDirection GetState(ILocomotive locomotive);
        void SetState(SpeedAndDirection data);
    }
}