using Microsoft.AspNetCore.Mvc;
using RailwayControlCentre;

namespace Mainline.Controllers
{
    [Route("api/[controller]")]
    public class TrainLinkController : Controller
    {
        private readonly IControlCentreService ControlService;

        public TrainLinkController(IControlCentreService controlService)
        {
            ControlService = controlService;
        }

        [HttpGet("[action]")]
        public TrainLinkStatus Status()
        {
            return new TrainLinkStatus()
            {
                Connected = ControlService.GetIsConnected()
            };
        }

        [HttpGet("[action]")]
        public TrainLinkStatus Connect()
        {
            ControlService.Connect();
            return new TrainLinkStatus()
            {
                Connected = ControlService.GetIsConnected()
            };
        }

        [HttpGet("[action]")]
        public TrainLinkStatus Disconnect()
        {
            ControlService.Disconnect();
            return new TrainLinkStatus()
            {
                Connected = ControlService.GetIsConnected()
            };
        }
    }
}