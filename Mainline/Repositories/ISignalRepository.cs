using System.Collections.Generic;
using Accessories.Signals;

namespace Mainline.Repositories
{
    public interface ISignalRepository
    {
        List<Signal> GetList();
        void Add(Signal newSignal);
    }
}