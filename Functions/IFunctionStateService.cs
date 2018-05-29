namespace Functions
{
    public interface IFunctionStateService
    {
        IFuncState GetState(int eAddress);
        void SetState(int eAddress, IFunc newState);
    }
}