using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Functions;
using Locomotives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
        public LocomotiveAndState TrainList()
        {
            List<ILocomotive> locomotives;

            string dir = @"C:\Projects\Mainline";
            string serializationFile = Path.Combine(dir, "trains.bin");

            using (Stream stream = new FileStream(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                locomotives = (List<ILocomotive>)bformatter.Deserialize(stream);
            }

            var state = LocomotiveStateService.GetState(locomotives);
            return new LocomotiveAndState()
            {
                Locomotives = locomotives,
                State = state
            };
        }

        [HttpGet("[action]")]
        public Boolean SaveTrainList()
        {
            var locomotiveAndState = TrainList(); // TODO console app to update this
            var trainList = locomotiveAndState.Locomotives;
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

        [HttpPost("[action]")]
        public void SetSpeedAndDirection([FromBody] SpeedAndDirection data)
        {
            ControlService.SetSpeedAndDirection(data);
            LocomotiveStateService.UpdateState(data);
        }
    }
}