namespace RailwayControlCentre
{
    public interface IArduinoControlCentreService
    {
        void Connect();
        void Disconnect();
        bool GetIsConnected();
        void SetLight(int nLightId, bool state);
    }
}