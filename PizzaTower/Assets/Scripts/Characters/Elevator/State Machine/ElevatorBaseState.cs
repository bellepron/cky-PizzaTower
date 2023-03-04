using cky.StateMachine.Base;

namespace PizzaTower.Characters.Elevator.StateMachine
{
    public abstract class ElevatorBaseState : BaseState
    {
        protected ElevatorStateMachine stateMachine;

        protected ElevatorBaseState(ElevatorStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}