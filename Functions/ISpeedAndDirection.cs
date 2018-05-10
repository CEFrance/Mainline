namespace Functions
{
    public interface ISpeedAndDirection
    {
        ushort EAddress { get; set; }
        EDirection Direction { get; set; }
        int Speed{ get; set; }

    }
}