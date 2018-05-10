using System;
using Functions;

namespace Locomotives
{
    [Serializable]
    public class SpeedAndDirection : ISpeedAndDirection
    {
        public ushort EAddress { get; set; }
        public EDirection Direction { get; set; }
        public int speed { get; set; }
    }
}