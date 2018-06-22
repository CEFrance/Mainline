using System.Collections.Generic;
using System.IO;
using System.Linq;
using Accessories.Signals;
using Newtonsoft.Json;

namespace Mainline.Repositories
{
    public class SignalRepository : ISignalRepository
    {
        private string serializationFile = "./../signals.json";
        private List<Signal> signals = new List<Signal>();

        public List<Signal> GetList()
        {
            if (signals.Any())
            {
                return signals;
            }

            signals = JsonConvert.DeserializeObject<List<Signal>>(File.ReadAllText(serializationFile));
            return signals;
        }

        public void Add(Signal newSignal)
        {
            var signalList = GetList();
            signalList.Add(newSignal);
            Save(signalList);
        }

        private void Save(List<Signal> signalList)
        {
            var contentsToWriteToFile = JsonConvert.SerializeObject(signalList, new JsonSerializerSettings
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