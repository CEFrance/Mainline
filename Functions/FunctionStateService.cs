using System.Collections.Generic;
using System.Linq;

namespace Functions
{
    public class FunctionStateService : IFunctionStateService
    {
        private readonly List<IFunctionState> functionState = new List<IFunctionState>();

        public IFunctionState GetFunctionState(int eAddress)
        {
            IFunctionState state = functionState.FirstOrDefault(o => o.EAddress == eAddress);
            if (state == null)
            {
                //state = new FunctionState()
                //{
                //    EAddress = eAddress
                //};
                //functionState.Add(state);
            }

            return state;
        }

        public void SetFunctionState(int eAddress, IFunction newFunctionState)
        {
            var state = GetFunctionState(eAddress);

            var functionState = state.Functions.FirstOrDefault(o => o.FunctionIndex == newFunctionState.FunctionIndex);
            functionState.FunctionType = newFunctionState.FunctionType;
            functionState.State = newFunctionState.State;
        }
    }
}