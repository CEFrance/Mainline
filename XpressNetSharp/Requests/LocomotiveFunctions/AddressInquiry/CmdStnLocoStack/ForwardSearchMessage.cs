﻿using System;

namespace XpressNetSharp.Requests.LocomotiveFunctions.AddressInquiry.CmdStnLocoStack
{
    /// <summary>
    /// Requests the next locomotive held within the command station stack.
    /// </summary>
    /// <remarks>
    /// The order of locomotives addresses held within the command station stack may not be sequential as they are returned in
    /// the order each locomotive was first used.
    /// 
    /// If the locomotive addresses within an command station is not known, set the address to 0 and the first address within the
    /// command station stack will be returned.
    /// </remarks>
    public class ForwardSearchMessage : Message
    {
        /// <summary>
        /// Requests the next locomotive held within the command station stack.
        /// </summary>
        /// <remarks>
        /// The order of locomotives addresses held within the command station stack may not be sequential as they are returned in
        /// the order each locomotive was first used.
        /// 
        /// If the locomotive addresses within an command station is not known, set the address to 0 and the first address within the
        /// command station stack will be returned.
        /// </remarks>
        /// <param name="address">Address of the locomotive (0 - 9999)</param>
        public ForwardSearchMessage(int address) 
            : base(PacketHeaderType.LocomotiveFunction) 
        {
            Payload.Add(Convert.ToByte(PacketIdentifier.LocomotiveFunctionRequest.AddressInquiryCmdStnLocoStack_ForwardSearch));

            byte[] data = new byte[2];

            if (address >= XpressNetConstants.MIN_LOCO_ADDRESS && address <= XpressNetConstants.MAX_LOCO_ADDRESS)
                ValueConverter.LocoAddress(address, out data[0], out data[1]);
            else
                throw new XpressNetProtocolViolationException("Number out of bounds");

            Payload.AddRange(data);
        }

        protected override bool ValidResponse(Packet packet)
        {
            if (packet.Header == PacketHeaderType.LocomotiveFunction && (packet.Payload[0] >= 0x30 && packet.Payload[0] <= 0x34)) //TODO: unit test to check this works
            {
                ResponseData = new AddressInquiryResp();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
