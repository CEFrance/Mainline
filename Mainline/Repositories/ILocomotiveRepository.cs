using System.Collections.Generic;
using Locomotives;

namespace Mainline.Repositories
{
    public interface ILocomotiveRepository
    {
        List<ILocomotive> GetList();
        void Add(ILocomotive newLocomotive);
    }
}