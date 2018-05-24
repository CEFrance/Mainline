using System.Collections.Generic;
using Accessories.Signals;
using ELink;
using Functions;
using Locomotives;

namespace RailwayControlCentre
{
    public class ControlCentreService : IControlCentreService
    {
        private readonly ELinkController eLinkController;

        public ControlCentreService()
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

        public void SetFunctions(int eAddress, List<IFunction> functions)
        {
            if (eLinkController.IsConnected)
            {
                eLinkController.SetLocomotiveFunction(eAddress, functions);
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
