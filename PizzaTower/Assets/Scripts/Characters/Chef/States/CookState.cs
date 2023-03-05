using PizzaTower.Characters.Chef.StateMachine;

namespace PizzaTower.Characters.Chef.States
{
    public class CookState : ChefBaseState
    {
        float _timeCounter;

        public CookState(ChefStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Cook();
        }

        public override void Exit()
        {
            stateMachine.AddPizza(stateMachine.PizzaCapacity);
        }

        public override void Tick(float deltaTime)
        {
            _timeCounter += deltaTime;
            if (_timeCounter >= stateMachine.CookTime)
            {
                FinishCooking();
            }
        }

        private void FinishCooking()
        {
            stateMachine.SwitchState(new GoToDeliveryPointState(stateMachine));
        }
    }
}