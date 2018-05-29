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

        public List<ILocomotive> GetList()
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

        public void Add(ILocomotive newLocomotive)
        {
            var locomotives = GetList();
            locomotives.Add(newLocomotive);
            SaveList(locomotives);
        }
        
        private void SaveList(List<ILocomotive> locomotives)
        {
            using (FileStream fileStream = new FileStream(SerializationFile, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(fileStream, locomotives);
            }
        }
    }
}