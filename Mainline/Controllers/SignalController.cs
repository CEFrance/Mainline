using System;
using System.Collections.Generic;
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
        private readonly IControlCentreService controlService;
        private readonly ISignalRepository signalRepository;

        public SignalController(IControlCentreService controlService, ISignalRepository signalRepository)
        {
            this.controlService = controlService;
            this.signalRepository = signalRepository;
        }

        [HttpGet("[action]")]
        public void AddTestSignal()
        {
            var newSignal = new Signal()
            {
                Id = Guid.NewGuid(),
                Functions = new EFunctions()
                {
                    EAddress = 2,
                },
                Aspects = new List<SignalColour>()
                {
                    SignalColour.Green,
                    SignalColour.Red
                },
                State = SignalColour.Green
            };
            signalRepository.Add(newSignal);
        }

        [HttpGet("[action]")]
        public void SetSignal(ushort signalAddress, SignalColour signalColour)
        {
            var signals = signalRepository.GetList();
            var signal = signals.First(o => o.Functions.EAddress == signalAddress);
            signal.State = signalColour;

            controlService.SetSignal(signal);
        }
    }
}