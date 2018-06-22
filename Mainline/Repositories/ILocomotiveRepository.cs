using System.Collections.Generic;
using Locomotives;

namespace Mainline.Repositories
{
    public interface ILocomotiveRepository
    {
        List<Locomotive> GetList();
        void Add(Locomotive newLocomotive);
    }
}