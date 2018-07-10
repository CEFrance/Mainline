using System.Collections.Generic;
using Accessories.Signals;
using ELink;
using Functions;
using Locomotives;

namespace RailwayControlCentre
{
    public class TrainControlCentreService : ITrainControlCentreService
    {
        private readonly ELinkController eLinkController;

        public TrainControlCentreService()
        {
            eLinkController = new ELinkController();
        }

        public bool GetIsConnected()
        {
            return eLinkController.IsConnected;
        }

        public void Connect()
        {
            eLinkController.Connect();
        }

        public void Disconnect()
        {
            eLinkController.Disconnect();
        }

        public void SetSpeedAndDirection(SpeedAndDirection data)
        {
            if (eLinkController.IsConnected)
            {
                eLinkController.SetLocomotiveSpeedAndDirection(data);
            }
        }

        public void SetFunctions(int eAddress, List<Func> functions)
        {
            if (eLinkController.IsConnected)
            {
                eLinkController.SetFunctions(eAddress, functions);
            }
        }

        public void SetSignal(ISignal signal)
        {
            if (eLinkController.IsConnected)
            {
                eLinkController.SetSignal(signal);
            }
        }
    }
}