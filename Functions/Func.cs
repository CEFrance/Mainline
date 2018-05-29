namespace Functions
{
    public class Func : IFunc
    {
        public int FunctionIndex { get; set; }
        public FuncType FuncType { get; set; }
        public FuncStates State { get; set; }
    }
}