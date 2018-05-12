using System.Collections.Generic;
using System.IO;
using Locomotives;

namespace Mainline.Controllers
{
    public class LocomotiveRepository : ILocomotiveRepository
    {
        private string SerializationFile = "./../trains.bin";
        
        public List<ILocomotive> GetTrainList()
        {
            using (Stream stream = new FileStream(SerializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (List<ILocomotive>)bformatter.Deserialize(stream);
            }
        }

        public void AddTrain(ILocomotive newLocomotive)
        {
            var trainList = GetTrainList();
            trainList.Add(newLocomotive);
            SaveTrainList(trainList);
        }
        
        private void SaveTrainList(List<ILocomotive> trainList)
        {
            using (FileStream fileStream = new FileStream(SerializationFile, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(fileStream, trainList);
            }
        }
    }
}