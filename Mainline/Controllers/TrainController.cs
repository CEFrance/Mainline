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
        private readonly ITrainControlCentreService controlService;
        private readonly ILocomotiveRepository locomotiveRepository;
        private readonly ILocomotiveStateService locomotiveStateService;
        private readonly IFunctionStateService funcStateService;

        public TrainController(ITrainControlCentreService controlService, ILocomotiveRepository locomotiveRepository, ILocomotiveStateService locomotiveStateService, IFunctionStateService funcStateService)
        {
            this.controlService = controlService;
            this.locomotiveRepository = locomotiveRepository;
            this.locomotiveStateService = locomotiveStateService;
            this.funcStateService = funcStateService;
        }

        [HttpGet("[action]")]
        public List<Locomotive> TrainList()
        {
            return locomotiveRepository.GetList();
        }

        [HttpGet("[action]")]
        public Boolean AddTrain()
        {
            //var locomotive4 = new Locomotive
            //{
            //    Configuration = "0-6-0",
            //    Functions = new EFunctions()
            //    {
            //        EAddress = 4,
            //        HasSound = false
            //    },
            //    Id = Guid.NewGuid(),
            //    Name = "King Richard II",
            //    Number = "2721",
            //    Owner = "GWR",
            //    Role = LocomotiveRole.Mixed,
            //    Type = LocomotiveType.Steam
            //};
            //locomotiveRepository.Add(locomotive4);

            var locomotive5 = new Locomotive
            {
                Configuration = "2-6-0",
                Functions = new EFunctions()
                {
                    EAddress = 5,
                    HasSound = true
                },
                Id = Guid.NewGuid(),
                Name = "King Richard II",
                Number = "6021",
                Owner = "British Rail",
                Role = LocomotiveRole.Passenger,
                Type = LocomotiveType.Steam
            };
            locomotiveRepository.Add(locomotive5);

            var locomotive6 = new Locomotive
            {
                Configuration = "4-4-2T",
                Functions = new EFunctions()
                {
                    EAddress = 6,
                    HasSound = false
                },
                Id = Guid.NewGuid(),
                Name = "",
                Number = "415",
                Owner = "LSWR",
                Role = LocomotiveRole.Mixed,
                Type = LocomotiveType.Steam
            };
            locomotiveRepository.Add(locomotive6);

            var locomotive7 = new Locomotive
            {
                Configuration = "2-6-4T",
                Functions = new EFunctions()
                {
                    EAddress = 7,
                    HasSound = false
                },
                Id = Guid.NewGuid(),
                Name = "",
                Number = "42334",
                Owner = "British Railways",
                Role = LocomotiveRole.Mixed,
                Type = LocomotiveType.Steam
            };
            locomotiveRepository.Add(locomotive7);

            var locomotive8 = new Locomotive
            {
                Configuration = "BoBo",
                Functions = new EFunctions()
                {
                    EAddress = 8,
                    HasSound = false
                },
                Id = Guid.NewGuid(),
                Name = "101 DMU",
                Number = "E51217",
                Owner = "British Railways",
                Role = LocomotiveRole.Passenger,
                Type = LocomotiveType.Diesel
            };
            locomotiveRepository.Add(locomotive8);
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
        public void SetFunction(int eAddress, Func func)
        {
            var func1 = new Func();
            func1.FunctionIndex = 1;
            func1.FuncType = FuncType.Lights;
            func1.State = FuncStates.On;

            funcStateService.SetState(eAddress, func1);
            var functionState = funcStateService.GetState(eAddress);

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