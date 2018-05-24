using System.Collections.Generic;
using Locomotives;

namespace Mainline.Repositories
{
    public interface ILocomotiveRepository
    {
        List<ILocomotive> GetTrainList();
        void AddTrain(ILocomotive newLocomotive);
    }
}