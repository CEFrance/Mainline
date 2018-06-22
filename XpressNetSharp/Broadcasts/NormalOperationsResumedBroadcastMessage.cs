using System;

namespace XpressNetSharp
{
    public class NormalOperationsResumedBroadcastMessage : Packet
    {
        public NormalOperationsResumedBroadcastMessage() : base(PacketHeaderType.CommandStationOperationResponse) 
        {
            Payload.Add(Convert.ToByte(PacketIdentifier.CommandStationOperationResponse.NormalOperationsResumedBroadcast));
        }
    }

    public class StartBroadcastMessage : Packet
    {
        public StartBroadcastMessage() : base(PacketHeaderType.CommandStationOperationsRequest)
        {
            Payload.Add(Convert.ToByte(36));
        }
    }
    public class StartBroadcastMessage2 : Packet
    {
        public StartBroadcastMessage2() : base(PacketHeaderType.CommandStationOperationResponse)
        {
            Payload.Add(Convert.ToByte(34));
            Payload.Add(Convert.ToByte(64));
        }
    }

    public class StartBroadcastMessage3 : Packet
    {
        public StartBroadcastMessage3() : base(PacketHeaderType.CommandStationOperationsRequest)
        {
            Payload.Add(Convert.ToByte(33));
        }
    }

    public class StartBroadcastMessage4 : Packet
    {
        public StartBroadcastMessage4() : base(PacketHeaderType.CommandStationOperationResponse)
        {
            Payload.Add(Convert.ToByte(33));
            Payload.Add(Convert.ToByte(107));
            Payload.Add(Convert.ToByte(1));
        }
    }

    public class StartBroadcastMessage5 : Packet
    {
        public StartBroadcastMessage5() : base(PacketHeaderType.LocomotiveFunction)
        {
            Payload.Add(Convert.ToByte(19));
            Payload.Add(Convert.ToByte(0));
            Payload.Add(Convert.ToByte(3));
            Payload.Add(Convert.ToByte(128));
        }
    }
}
