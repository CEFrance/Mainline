namespace Functions
{
    public interface IFunc
    {
        int FunctionIndex { get; set; }
        FuncType FuncType { get; set; }
        FuncStates State { get; set; }
    }
}