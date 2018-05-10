using ELink;
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

        public void SetSpeedAndDirection(SpeedAndDirection data)
        {
            if (eLinkController.IsConnected)
            {
                eLinkController.SetLocomotiveSpeedAndDirection(data);
            }
        }

        public void Connect()
        {
            eLinkController.Connect();
        }

        public void Disconnect()
        {
            eLinkController.Disconnect();
        }
    }
}
