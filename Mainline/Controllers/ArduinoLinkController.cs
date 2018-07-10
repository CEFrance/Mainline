using Microsoft.AspNetCore.Mvc;
using RailwayControlCentre;

namespace Mainline.Controllers
{
    [Route("api/[controller]")]
    public class ArduinoLinkController : Controller
    {
        private readonly IArduinoControlCentreService controlService;

        public ArduinoLinkController(IArduinoControlCentreService controlService)
        {
            this.controlService = controlService;
        }

        [HttpGet("[action]")]
        public ConnectionLinkStatus Status()
        {
            return new ConnectionLinkStatus()
            {
                Connected = controlService.GetIsConnected()
            };
        }

        [HttpGet("[action]")]
        public ConnectionLinkStatus Connect()
        {
            controlService.Connect();
            return new ConnectionLinkStatus()
            {
                Connected = controlService.GetIsConnected()
            };
        }

        [HttpGet("[action]")]
        public ConnectionLinkStatus Disconnect()
        {
            controlService.Disconnect();
            return new ConnectionLinkStatus()
            {
                Connected = controlService.GetIsConnected()
            };
        }

        [HttpGet("[action]")]
        public void SetLight(int nLightId, bool state)
        {
            controlService.SetLight(nLightId, state);
        }
        
    }
}