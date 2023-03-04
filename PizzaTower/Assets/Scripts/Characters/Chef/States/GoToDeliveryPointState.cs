using cky.Reuseables.Extension;
using PizzaTower.Characters.Chef.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.Chef.States
{
    public class GoToDeliveryPointState : ChefBaseState
    {
        Transform _chefTr;
        Vector3 _chefDeliveryPoint;
        Vector3 _direction;

        public GoToDeliveryPointState(ChefStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.WalkWithPizza();

            _chefTr = stateMachine.transform;
            _chefDeliveryPoint = new Vector3(stateMachine.ChefDeliveryPointX, _chefTr.localPosition.y, 0);
        }

        public override void Exit() { }

        public override void Tick(float deltaTime)
        {
            _direction = _chefTr.LocalUnitDirectionX(_chefDeliveryPoint);

            _chefTr.localPosition += _direction * stateMachine.MovementSpeed * deltaTime;

            if (Mathf.Abs(_chefDeliveryPoint.x - _chefTr.localPosition.x) < 0.1f)
            {
                _chefTr.localPosition = _chefDeliveryPoint;
                stateMachine.SwitchState(new DeliverState(stateMachine));
            }
        }
    }
}