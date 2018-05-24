namespace Functions
{
    public interface IFunctionStateService
    {
        IFunctionState GetFunctionState(int eAddress);
        void SetFunctionState(int eAddress, IFunction newFunctionState);
    }
}