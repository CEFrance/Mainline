using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Locomotives;
using Microsoft.AspNetCore.Mvc;
using RailwayControlCentre;

namespace Mainline.Controllers
{
    [Route("api/[controller]")]
    public class TrainController : Controller
    {
        private readonly IControlCentreService ControlService;
        private readonly ILocomotiveStateService LocomotiveStateService;

        public TrainController(IControlCentreService controlService, ILocomotiveStateService locomotiveStateService)
        {
            ControlService = controlService;
            LocomotiveStateService = locomotiveStateService;
        }

        [HttpGet("[action]")]
        public List<ILocomotive> TrainList()
        {
            string serializationFile = "./../trains.bin";

            using (Stream stream = new FileStream(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (List<ILocomotive>)bformatter.Deserialize(stream);
            }
        }

        [HttpGet("[action]")]
        public Boolean SaveTrainList()
        {
            var trainList = TrainList(); // TODO console app to update this
            var temp = trainList.Last();

            //trainList.Add(new DieselLocomotive()
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
             
            string dir = @"C:\Projects\Mainline";
            string serializationFile = Path.Combine(dir, "trains.bin");

            using (FileStream fileStream = new FileStream(serializationFile, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(fileStream, trainList);
            }

            return true;
        }

        [HttpGet("[action]")]
        public SpeedAndDirection GetSpeedAndDirection(int eAddress)
        {
            var train = _GetTrain(eAddress);
            return LocomotiveStateService.GetState(train);
        }

        [HttpPost("[action]")]
        public void SetSpeedAndDirection([FromBody] SpeedAndDirection data)
        {
            _GetTrain(data.EAddress);

            LocomotiveStateService.SetState(data);
            ControlService.SetSpeedAndDirection(data);
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