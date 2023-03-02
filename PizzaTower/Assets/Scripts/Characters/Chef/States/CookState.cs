
namespace PizzaTower.Characters.Chef.States
{
    public class CookState : ChefBaseState
    {
        float _timeCounter;

        public CookState(ChefStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Cook();

            _timeCounter = stateMachine.CookTime;
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            _timeCounter -= deltaTime;
            if (_timeCounter <= 0.0f)
            {
                stateMachine.SwitchState(new GoToDeliveryPointState(stateMachine));
            }
        }
    }
}