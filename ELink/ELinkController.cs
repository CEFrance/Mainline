using System;
using System.IO.Ports;
using System.Threading.Tasks;
using Functions;
using Locomotives;
using XpressNetSharp;

namespace ELink
{
    public class ELinkController : IDisposable
    {
        private SerialPort SerialPort;
        public bool IsConnected { get; set; }

        public ELinkController()
        {
            IsConnected = false;
        }

        public void Connect()
        {
            SerialPort = new SerialPort("Com3", 115200, Parity.None, 8, StopBits.One);
            SerialPort.Open();
            SerialPort.DiscardInBuffer();
            SerialPort.DiscardOutBuffer();

            IsConnected = true;
        }

        public async Task<bool> SetLocomotiveSpeedAndDirection(SpeedAndDirection data)
        {
            var msg = new SetLocoSpeedAndDirection_SpeedSteps128Message(data.EAddress, (byte) data.speed, (data.Direction == EDirection.Forwards) ? Direction.Forward : Direction.Reverse);
            await msg.WriteAsync(SerialPort.BaseStream);
            return true;
        }

        public void Disconnect()
        {
            Dispose();
        }

        public void Dispose()
        {
            SerialPort?.Dispose();
            IsConnected = false;
        }
    }
}