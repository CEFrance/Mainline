using System.Collections.Generic;
using System.IO;
using System.Linq;
using Locomotives;

namespace Mainline.Repositories
{
    public class LocomotiveRepository : ILocomotiveRepository
    {
        private string SerializationFile = "./../trains.bin";
        private List<ILocomotive> locomotives = new List<ILocomotive>();

        public List<ILocomotive> GetTrainList()
        {
            if (locomotives.Any())
            {
                return locomotives;
            }

            using (Stream stream = new FileStream(SerializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                locomotives = (List<ILocomotive>)bformatter.Deserialize(stream);
                return locomotives;
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