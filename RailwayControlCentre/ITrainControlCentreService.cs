using System.Collections.Generic;
using Accessories.Signals;
using Functions;
using Locomotives;

namespace RailwayControlCentre
{
    public interface ITrainControlCentreService
    {
        void Connect();
        void Disconnect();
        bool GetIsConnected();
        void SetSpeedAndDirection(SpeedAndDirection data);
        void SetFunctions(int eAddress, List<Func> functions);
        void SetSignal(ISignal signal);
    }
}