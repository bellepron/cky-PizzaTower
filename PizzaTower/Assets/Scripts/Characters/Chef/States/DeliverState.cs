using PizzaTower.Characters.Chef.StateMachine;

namespace PizzaTower.Characters.Chef.States
{
    public class DeliverState : ChefBaseState
    {
        public DeliverState(ChefStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.FloorSupervisor.AddPizza(stateMachine.PizzaCount);
            stateMachine.RemovePizzas();

            stateMachine.SwitchState(new GoToTableState(stateMachine));
        }

        public override void Exit() { }

        public override void Tick(float deltaTime) { }
    }
}