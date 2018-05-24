namespace Functions
{
    public class Function : IFunction
    {
        public int FunctionIndex { get; set; }
        public FunctionType FunctionType { get; set; }
        public FunctionStates State { get; set; }
    }
}