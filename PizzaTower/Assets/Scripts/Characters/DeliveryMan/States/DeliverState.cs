using PizzaTower.Characters.DeliveryMan.StateMachine;

namespace PizzaTower.Characters.DeliveryMan.States
{
    public class DeliverState : DeliveryManBaseState
    {
        public DeliverState(DeliveryManStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.EventManager.TriggerUpdateCoin(stateMachine.PizzaCount.ToString());
            stateMachine.RemovePizzas();

            stateMachine.SwitchState(new GoToParkingPointState(stateMachine));
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {

        }
    }
}