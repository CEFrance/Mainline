using System.Collections.Generic;
using System.IO;
using System.Linq;
using Locomotives;
using Newtonsoft.Json;

namespace Mainline.Repositories
{
    public class LocomotiveRepository : ILocomotiveRepository
    {
        private string serializationFile = "./../trains.json";
        private List<Locomotive> locomotives = new List<Locomotive>();

        public List<Locomotive> GetList()
        {
            if (locomotives.Any())
            {
                return locomotives;
            }

            locomotives = JsonConvert.DeserializeObject<List<Locomotive>>(File.ReadAllText(serializationFile));
            return locomotives;
        }

        public void Add(Locomotive newLocomotive)
        {
            var locomotiveList = GetList();
            locomotiveList.Add(newLocomotive);
            SaveList(locomotiveList);
        }
        
        private void SaveList(List<Locomotive> locomotiveList)
        {
            var contentsToWriteToFile = JsonConvert.SerializeObject(locomotiveList, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });
            using (var writer = new StreamWriter(serializationFile))
            {
                writer.Write(contentsToWriteToFile);
            }
        }
    }
}