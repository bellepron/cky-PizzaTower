using cky.StateMachine.Base;

namespace PizzaTower.Characters.DeliveryMan.StateMachine
{
    public abstract class DeliveryManBaseState : BaseState
    {
        protected DeliveryManStateMachine stateMachine;

        public DeliveryManBaseState(DeliveryManStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}