using System;
using System.IO.Ports;

namespace Arduino
{
    public class ArduinoController : IDisposable
    {
        private SerialPort serialPort;
        public bool IsConnected { get; set; }

        public ArduinoController()
        {
            IsConnected = false;
        }

        public void Connect()
        {
            serialPort = new SerialPort("Com5", 9600, Parity.None, 8, StopBits.One);
            serialPort.Open();
            IsConnected = true;
        }

        public void Dispose()
        {
            serialPort.Close();
            serialPort = null;
        }

        public void Disconnect()
        {
            Dispose();
        }

        public void SetLight(int lightId, bool state)
        {
            var onOffString = state ? "On" : "Off";
            serialPort.WriteLine($"lgt{lightId}{onOffString}");
        }
    }
}
