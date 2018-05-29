using Microsoft.AspNetCore.Mvc;
using RailwayControlCentre;

namespace Mainline.Controllers
{
    [Route("api/[controller]")]
    public class TrainLinkController : Controller
    {
        private readonly IControlCentreService controlService;

        public TrainLinkController(IControlCentreService controlService)
        {
            this.controlService = controlService;
        }

        [HttpGet("[action]")]
        public TrainLinkStatus Status()
        {
            return new TrainLinkStatus()
            {
                Connected = controlService.GetIsConnected()
            };
        }

        [HttpGet("[action]")]
        public TrainLinkStatus Connect()
        {
            controlService.Connect();
            return new TrainLinkStatus()
            {
                Connected = controlService.GetIsConnected()
            };
        }

        [HttpGet("[action]")]
        public TrainLinkStatus Disconnect()
        {
            controlService.Disconnect();
            return new TrainLinkStatus()
            {
                Connected = controlService.GetIsConnected()
            };
        }
    }
}