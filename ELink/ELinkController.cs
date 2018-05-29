using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using Accessories.Signals;
using Functions;
using Locomotives;
using XpressNetSharp;

namespace ELink
{
    public class ELinkController : IDisposable
    {
        private SerialPort serialPort;
        public bool IsConnected { get; set; }

        public ELinkController()
        {
            IsConnected = false;
        }

        public void Connect()
        {
            serialPort = new SerialPort("Com3", 115200, Parity.None, 8, StopBits.One);
            serialPort.Open();
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            ResumeOperations();

            IsConnected = true;
        }

        public void SetLocomotiveSpeedAndDirection(SpeedAndDirection data)
        {
            var msg = new SetLocoSpeedAndDirection_SpeedSteps128Message(data.EAddress, (byte) data.speed, (data.Direction == EDirection.Forwards) ? Direction.Forward : Direction.Reverse);
            msg.Write(serialPort.BaseStream);
        }

        public void SetFunctions(int eAddress, List<IFunc> functionList)
        {
            var group1Functions = _GetGroup1FunctionMapping(functionList);
            //var group2Functions = _GetGroup2FunctionMapping(functionList);

            var msg = new SetFunctionOperationInstruction_Group1Message(eAddress, group1Functions[0], group1Functions[1], group1Functions[2], group1Functions[3], group1Functions[4]);
            msg.Write(serialPort.BaseStream);

            // We need to reset sound functions
            //msgFunction = new SetFunctionOperationInstruction_Group1Message(eAddress, FunctionState.Off, FunctionState.Off, FunctionState.Off, FunctionState.Off, FunctionState.Off);
            //msgFunction.Write(SerialPort.BaseStream);
        }
        
        public void Disconnect()
        {
            var msg = new TrackPowerOffBroadcastMessage();
            msg.Write(serialPort.BaseStream);

            Dispose();
        }

        public void Dispose()
        {
            serialPort?.Dispose();
            IsConnected = false;
        }

        private void ResumeOperations()
        {
            var msg = new NormalOperationsResumedBroadcastMessage();
            msg.Write(serialPort.BaseStream);
        }

        private FuncState[] _GetGroup1FunctionMapping(List<IFunc> functionList)
        {
            var functionsInGroup = 5;

            FuncState[] functionMapping = { };

            for (var cursor = 0; cursor < functionsInGroup; cursor++)
            {
                var function = functionList.FirstOrDefault(o => o.FunctionIndex == cursor);
                functionMapping[cursor] = function != null ? (function.State == FuncStates.On ? FunctionState.On : FunctionState.Off) : FunctionState.Off;
            }

            return functionMapping;
        }

        public void SetSignal(ISignal signal)
        {
            AccessoryState state = AccessoryState.Activate;
            ushort address = signal.Functions.EAddress;

            switch (signal.State)
            {
                case SignalColour.Green:
                    state = AccessoryState.Deactivate;
                    break;

                case SignalColour.Yellow:
                    address++;
                    break;

                case SignalColour.DoubleYellow:
                    state = AccessoryState.Deactivate;
                    address++;
                    break;
            }

            var msgSetup = new AccDecoderOperationsReqMessage(address, state, AccessoryOutput.One);
            msgSetup.Write(serialPort.BaseStream);
        }
    }
}