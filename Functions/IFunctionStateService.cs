namespace Functions
{
    public interface IFunctionStateService
    {
        FuncState GetState(int eAddress);
        void SetState(int eAddress, Func newState);
    }
}