using Functions;

namespace Locomotives
{
    public interface ISpeedAndDirection
    {
        ushort EAddress { get; set; }
        EDirection Direction { get; set; }
        int speed{ get; set; }
    }
}