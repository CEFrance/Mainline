using System;
using System.Collections.Generic;
using System.Linq;
using Functions;
using Locomotives;
using Mainline.Repositories;
using Microsoft.AspNetCore.Mvc;
using RailwayControlCentre;

namespace Mainline.Controllers
{
    [Route("api/[controller]")]
    public class TrainController : Controller
    {
        private readonly IControlCentreService controlService;
        private readonly ILocomotiveRepository locomotiveRepository;
        private readonly ILocomotiveStateService locomotiveStateService;
        private readonly IFunctionStateService functionStateService;

        public TrainController(IControlCentreService controlService, ILocomotiveRepository locomotiveRepository, ILocomotiveStateService locomotiveStateService, IFunctionStateService functionStateService)
        {
            this.controlService = controlService;
            this.locomotiveRepository = locomotiveRepository;
            this.locomotiveStateService = locomotiveStateService;
            this.functionStateService = functionStateService;
        }

        [HttpGet("[action]")]
        public List<ILocomotive> TrainList()
        {
            return locomotiveRepository.GetList();
        }

        [HttpGet("[action]")]
        public Boolean AddTrain()
        {
            //var locomotive = new DieselLocomotive()
            //{
            //    Configuration = "BoBo",
            //    Functions = new EFunctions()
            //    {
            //        EAddress = 8,
            //        HasSound = false
            //    },
            //    Id = Guid.NewGuid(),
            //    Name = "101 DMU",
            //    Number = "E51217",
            //    Owner = "British Railways",
            //    Role = LocomotiveRole.Passenger
            //});
            //LocomotiveRepository.AddLocomotive(locomotive);
            return true;
        }

        [HttpGet("[action]")]
        public List<SpeedAndDirection> GetSpeedAndDirection(int eAddress)
        {
            var stateList = new List<SpeedAndDirection>();

            foreach (ILocomotive locomotive in TrainList())
            {
                stateList.Add(locomotiveStateService.GetState(locomotive));
            }

            return stateList;
        }

        [HttpGet("[action]")]
        public void SetFunction(int eAddress, IFunction function)
        {
            var func = new Function();
            func.FunctionIndex = 1;
            func.FunctionType = FunctionType.Lights;
            func.State = FunctionStates.On;

            functionStateService.SetFunctionState(eAddress, function);
            var functionState = functionStateService.GetFunctionState(eAddress);

            controlService.SetFunctions(eAddress, functionState.Functions);
        }

        [HttpPost("[action]")]
        public void SetSpeedAndDirection([FromBody] SpeedAndDirection data)
        {
            _GetTrain(data.EAddress);

            locomotiveStateService.SetState(data);
            controlService.SetSpeedAndDirection(data);
        }

        private ILocomotive _GetTrain(int eAddress)
        {
            var trainList = TrainList();
            var train = trainList.FirstOrDefault(o => o.Functions.EAddress == eAddress);
            if (train == null)
            {
                throw new Exception($"Failed to find train with id: {eAddress}");
            }

            return train;
        }
    }
}