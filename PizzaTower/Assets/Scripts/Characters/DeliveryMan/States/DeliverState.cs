using PizzaTower.Characters.DeliveryMan.StateMachine;

namespace PizzaTower.Characters.DeliveryMan.States
{
    public class DeliverState : DeliveryManBaseState
    {
        public DeliverState(DeliveryManStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            stateMachine.SwitchState(new GoToParkingPointState(stateMachine));
        }
    }
}