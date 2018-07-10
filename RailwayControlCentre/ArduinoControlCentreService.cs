
using Arduino;

namespace RailwayControlCentre
{
    public class ArduinoControlCentreService : IArduinoControlCentreService
    {
        private readonly ArduinoController arduinoController;

        public ArduinoControlCentreService()
        {
            arduinoController = new ArduinoController();
        }

        public bool GetIsConnected()
        {
            return arduinoController.IsConnected;
        }

        public void Connect()
        {
            arduinoController.Connect();
        }

        public void Disconnect()
        {
            arduinoController.Disconnect();
        }

        public void SetLight(int lightId, bool state)
        {
            if (arduinoController.IsConnected)
            {
                arduinoController.SetLight(lightId, state);
            }
        }
    }
}