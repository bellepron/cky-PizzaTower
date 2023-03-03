using cky.Reuseables.Extension;
using PizzaTower.Characters.DeliveryMan.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.DeliveryMan.States
{
    public class GoToDeliveryPointState : DeliveryManBaseState
    {
        Transform _deliveryManTr;
        Vector3 _deliveryPoint;
        Vector3 _direction;

        public GoToDeliveryPointState(DeliveryManStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _deliveryManTr = stateMachine.transform;
            _deliveryPoint = stateMachine.DeliveryPoint;
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            _direction = _deliveryManTr.WorldUnitDirectionX(_deliveryPoint);

            _deliveryManTr.transform.localPosition += _direction * stateMachine.MovementSpeed * deltaTime;

            if (Mathf.Abs(_deliveryPoint.x - _deliveryManTr.position.x) < 0.1f)
            {
                _deliveryManTr.position = _deliveryPoint;
                stateMachine.SwitchState(new DeliverState(stateMachine));
            }
        }
    }
}