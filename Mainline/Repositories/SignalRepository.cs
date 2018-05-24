using System.Collections.Generic;
using System.IO;
using System.Linq;
using Accessories.Signals;

namespace Mainline.Repositories
{
    public class SignalRepository : ISignalRepository
    {
        private string SerializationFile = "./../signals.bin";
        private List<ISignal> signals = new List<ISignal>();

        public List<ISignal> GetSignalList()
        {
            if (Enumerable.Any<ISignal>(signals))
            {
                return signals;
            }

            using (Stream stream = new FileStream(SerializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                signals = (List<ISignal>)bformatter.Deserialize(stream);
                return signals;
            }
        }

        public void AddSignal(ISignal newSignal)
        {
            var signalList = GetSignalList();
            signalList.Add(newSignal);
            SaveSignalList(signalList);
        }

        private void SaveSignalList(List<ISignal> signalList)
        {
            using (FileStream fileStream = new FileStream(SerializationFile, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(fileStream, signalList);
            }
        }
    }
}