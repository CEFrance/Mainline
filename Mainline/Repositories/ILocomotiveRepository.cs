using System.Collections.Generic;
using Locomotives;

namespace Mainline.Controllers
{
    public interface ILocomotiveRepository
    {
        List<ILocomotive> GetTrainList();
    }
}