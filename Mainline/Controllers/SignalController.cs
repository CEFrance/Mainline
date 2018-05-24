using System;
using System.Linq;
using Accessories.Signals;
using Functions;
using Mainline.Repositories;
using Microsoft.AspNetCore.Mvc;
using RailwayControlCentre;

namespace Mainline.Controllers
{
    [Route("api/[controller]")]
    public class SignalController : Controller
    {
        private readonly IControlCentreService ControlService;
        private readonly ISignalRepository SignalRepository;

        public SignalController(IControlCentreService controlService, ISignalRepository signalRepository)
        {
            ControlService = controlService;
            SignalRepository = signalRepository;
        }

        [HttpGet("[action]")]
        public void AddTestSignal()
        {
            var newSignal = new FourLightSignal()
            {
                Id = Guid.NewGuid(),
                Functions = new EFunctions()
                {
                    EAddress = 2
                },
                State = SignalColour.Green
            };
            SignalRepository.AddSignal(newSignal);
        }

        [HttpGet("[action]")]
        public void SetSignal(ushort signalAddress, SignalColour signalColour)
        {
            var signals = SignalRepository.GetSignalList();
            var signal = signals.First(o => o.Functions.EAddress == signalAddress);
            signal.State = signalColour;

            ControlService.SetSignal(signal);
        }
    }
}