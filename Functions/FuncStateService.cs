using System.Collections.Generic;
using System.Linq;

namespace Functions
{
    public class FuncStateService : IFunctionStateService
    {
        private readonly List<FuncState> functionState = new List<FuncState>();

        public FuncState GetState(int eAddress)
        {
            FuncState state = functionState.FirstOrDefault(o => o.EAddress == eAddress);
            if (state == null)
            {
                state = new FuncState()
                {
                    EAddress = eAddress
                };
                functionState.Add(state);
            }

            return state;
        }

        public void SetState(int eAddress, Func newState)
        {
            var state = GetState(eAddress);

            var funcState = state.Functions.FirstOrDefault(o => o.FunctionIndex == newState.FunctionIndex);
            if (funcState == null)
            {
                funcState = new Func();
                state.Functions.Add(funcState);
            }

            funcState.FunctionIndex = newState.FunctionIndex;
            funcState.FuncType = newState.FuncType;
            funcState.State = newState.State;
        }
    }
}