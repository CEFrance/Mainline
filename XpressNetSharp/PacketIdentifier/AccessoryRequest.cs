using System;

namespace XpressNetSharp.PacketIdentifier
{
    [Flags]
    public enum AccessoryRequest : byte
    {
        AccessoryFunction = 0x52
    }
}