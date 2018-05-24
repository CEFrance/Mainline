using System.Collections.Generic;
using System.Linq;
using Functions;
using Locomotives;

namespace RailwayControlCentre
{
    public class LocomotiveStateService : ILocomotiveStateService
    {
        private readonly List<SpeedAndDirection> speedAndDirectionState = new List<SpeedAndDirection>();

        public SpeedAndDirection GetState(ILocomotive locomotive)
        {
            SpeedAndDirection speedAndDirection = speedAndDirectionState.FirstOrDefault(o => o.EAddress == locomotive.Functions.EAddress);
            if (speedAndDirection == null)
            {
                speedAndDirection = new SpeedAndDirection()
                {
                    EAddress = locomotive.Functions.EAddress,
                    speed = 0,
                    Direction = EDirection.Forwards
                };
                speedAndDirectionState.Add(speedAndDirection);
            }

            return speedAndDirection;
        }

        public void SetState(SpeedAndDirection data)
        {
            SpeedAndDirection speedAndDirection = speedAndDirectionState.FirstOrDefault(o => o.EAddress == data.EAddress);
            if (speedAndDirection == null)
            {
                speedAndDirectionState.Add(data);
            }
            else
            {
                speedAndDirection.speed = data.speed;
                speedAndDirection.Direction = data.Direction;
            }
        }
    }
}