using Locomotives;

namespace RailwayControlCentre
{
    public interface IControlCentreService
    {
        void Connect();
        void Disconnect();
        bool GetIsConnected();
        void SetSpeedAndDirection(SpeedAndDirection data);
    }
}