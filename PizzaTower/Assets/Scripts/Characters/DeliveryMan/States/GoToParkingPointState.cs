using cky.Reuseables.Extension;
using PizzaTower.Characters.DeliveryMan.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.DeliveryMan.States
{
    public class GoToParkingPointState : DeliveryManBaseState
    {
        Transform _deliveryManTr;
        Vector3 _parkPoint;
        Vector3 _direction;

        public GoToParkingPointState(DeliveryManStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.SpriteRenderer.flipX = true;

            _deliveryManTr = stateMachine.transform;
            _parkPoint = stateMachine.ParkingPoint;
        }

        public override void Exit()
        {
            stateMachine.SpriteRenderer.flipX = false;
        }

        public override void Tick(float deltaTime)
        {
            if (stateMachine.ParkSupervisor.PizzaCount == 0)
                return;

            _direction = _deliveryManTr.WorldUnitDirectionX(_parkPoint);

            _deliveryManTr.transform.localPosition += _direction * stateMachine.MovementSpeed * deltaTime;

            if (Mathf.Abs(_parkPoint.x - _deliveryManTr.position.x) < 0.1f)
            {
                _deliveryManTr.position = _parkPoint;

                ArrivedToTheParkPoint();
            }
        }

        private void ArrivedToTheParkPoint()
        {
            stateMachine.EventManager.TriggerDeliveryManArrivedToParkSupervisor(stateMachine, stateMachine.Capacity);

            stateMachine.SwitchState(new GetDeliveryState(stateMachine));
        }
    }
}