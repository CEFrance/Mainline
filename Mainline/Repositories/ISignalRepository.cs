using System.Collections.Generic;
using Accessories.Signals;

namespace Mainline.Repositories
{
    public interface ISignalRepository
    {
        List<ISignal> GetList();
        void Add(ISignal newSignal);
    }
}