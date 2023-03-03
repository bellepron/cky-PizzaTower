using PizzaTower.Characters.DeliveryMan.StateMachine;

namespace PizzaTower.Characters.DeliveryMan.States
{
    public class GetDeliveryState : DeliveryManBaseState
    {
        float _timeCounter;

        public GetDeliveryState(DeliveryManStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            _timeCounter += deltaTime;
            if (_timeCounter >= stateMachine.GettingDeliveryTime)
            {
                stateMachine.SwitchState(new GoToDeliveryPointState(stateMachine));
            }
        }
    }
}