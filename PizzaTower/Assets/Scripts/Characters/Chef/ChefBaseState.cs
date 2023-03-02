using cky.StateMachine.Base;

namespace PizzaTower.Characters.Chef
{
    public abstract class ChefBaseState : BaseState
    {
        protected ChefStateMachine stateMachine;

        protected ChefBaseState(ChefStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}