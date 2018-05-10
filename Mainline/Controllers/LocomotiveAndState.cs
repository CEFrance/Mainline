using System.Collections.Generic;
using Locomotives;

namespace Mainline.Controllers
{
    public class LocomotiveAndState 
    {
        public List<ILocomotive> Locomotives { get; set; }
        public List<SpeedAndDirection> State { get; set; }
    }
}