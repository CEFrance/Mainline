namespace Functions
{
    public interface IFunction
    {
        int FunctionIndex { get; set; }
        FunctionType FunctionType { get; set; }
        FunctionStates State { get; set; }
    }
}