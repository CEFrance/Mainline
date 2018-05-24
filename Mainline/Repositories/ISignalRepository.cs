using System.Collections.Generic;
using Accessories.Signals;

namespace Mainline.Repositories
{
    public interface ISignalRepository
    {
        List<ISignal> GetSignalList();
        void AddSignal(ISignal newSignal);
    }
}