using System.Collections.Generic;
using System.Linq;
using Functions;
using Locomotives;

namespace RailwayControlCentre
{
    public class LocomotiveStateService : ILocomotiveStateService
    {
        public List<SpeedAndDirection> state = new List<SpeedAndDirection>();

        public SpeedAndDirection GetState(ILocomotive locomotive)
        {
            SpeedAndDirection speedAndDirection = state.FirstOrDefault(o => o.EAddress == locomotive.Functions.EAddress);
            if (speedAndDirection == null)
            {
                speedAndDirection = new SpeedAndDirection()
                {
                    EAddress = locomotive.Functions.EAddress,
                    speed = 10,
                    Direction = EDirection.Forwards
                };
                state.Add(speedAndDirection);
            }

            return speedAndDirection;
        }

        public void SetState(SpeedAndDirection data)
        {
            SpeedAndDirection speedAndDirection = state.FirstOrDefault(o => o.EAddress == data.EAddress);
            if (speedAndDirection == null)
            {
                state.Add(data);
            }
            else
            {
                speedAndDirection.speed = data.speed;
                speedAndDirection.Direction = data.Direction;
            }
        }
    }
}