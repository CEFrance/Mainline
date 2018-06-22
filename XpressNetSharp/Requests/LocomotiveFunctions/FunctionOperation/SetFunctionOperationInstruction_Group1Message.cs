using System;
using XpressNetSharp.PacketIdentifier;

namespace XpressNetSharp
{
    /// <summary>
    /// Sets the state of functions 0 to 4 of a locomotive
    /// </summary>
    public class SetFunctionOperationInstruction_Group1Message : Packet
    {
        /// <summary>
        /// Sets the state of functions 0 to 4 of a locomotive
        /// </summary>
        /// <param name="address">Address of the locomotive (0 - 9999)</param>
        /// <param name="f0">Function 0</param>
        /// <param name="f1">Function 1</param>
        /// <param name="f2">Function 2</param>
        /// <param name="f3">Function 3</param>
        /// <param name="f4">Function 4</param>
        public SetFunctionOperationInstruction_Group1Message(int address, FunctionState f0, FunctionState f1, FunctionState f2, FunctionState f3, FunctionState f4) 
            : base(PacketHeaderType.LocomotiveFunction) 
        {
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.LocoInfo));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddressInquiryMultiUnitMember_ForwardSearch));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddressInquiryMultiUnitMember_BackwardSearch));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddressInquiryMultiUnit_ForwardSearch));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddressInquiryMultiUnit_BackwardSearch));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddressInquiryCmdStnLocoStack_ForwardSearch));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddressInquiryCmdStnLocoStack_BackwardSearch));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.FunctionStatus));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.FunctionStatus13to28));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.FunctionLevel13to28));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetLocoSpeedAndDirection_SpeedSteps14));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetLocoSpeedAndDirection_SpeedSteps27));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetLocoSpeedAndDirection_SpeedSteps28));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetLocoSpeedAndDirection_SpeedSteps128));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionOperationInstruction_Group1));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionOperationInstruction_Group2));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionOperationInstruction_Group3));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionOperationInstruction_Group4));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionState_Group1));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionState_Group2));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionState_Group3));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionState_Group4));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionOperationInstruction_Group5));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.SetFunctionState_Group5));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.RefreshFunctionMode));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.OperationsModeWrite));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddLocoToMultiUnit));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.AddLocoToMultiUnit_ReversedDirection));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.RemoveLocoFromMultiUnit));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.EstablishOrDesolveDoubleHeader));
            Console.WriteLine(Convert.ToByte(LocomotiveFunctionRequest.DeleteLocoFromCmdStnStack));

            Payload.Add(Convert.ToByte(PacketIdentifier.LocomotiveFunctionRequest.SetFunctionOperationInstruction_Group1));

            byte[] data = new byte[3];

            if (address >= XpressNetConstants.MIN_LOCO_ADDRESS && address <= XpressNetConstants.MAX_LOCO_ADDRESS)
                ValueConverter.LocoAddress(address, out data[0], out data[1]);
            else
                throw new XpressNetProtocolViolationException("Number out of bounds");

            data[2] = 0x00;
            // E4-20-00-03-01-C6 Sound on

            if(f0 == FunctionState.On)
                data[2] |= 1;

            if (f4 == FunctionState.On)
                data[2] |= 2;

            if (f3 == FunctionState.On)
                data[2] |= 4;

            if (f2 == FunctionState.On)
                data[2] |= 8;

            if (f1 == FunctionState.On)
                data[2] |= 16;

            Payload.AddRange(data);
        }
    }
}
