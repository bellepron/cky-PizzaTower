using cky.Reuseables.Extension;
using PizzaTower.Characters.DeliveryMan.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.DeliveryMan.States
{
    public class GoToParkingPointState : DeliveryManBaseState
    {
        Transform _deliveryManTr;
        Vector3 _parkingPoint;
        Vector3 _direction;
        SpriteRenderer _spriteRenderer;

        public GoToParkingPointState(DeliveryManStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _spriteRenderer = stateMachine.GetComponent<SpriteRenderer>();
            _spriteRenderer.flipX = true;

            _deliveryManTr = stateMachine.transform;
            _parkingPoint = stateMachine.ParkingPoint;
        }

        public override void Exit()
        {

            _spriteRenderer.flipX = false;
        }

        public override void Tick(float deltaTime)
        {
            _direction = _deliveryManTr.WorldUnitDirectionX(_parkingPoint);

            _deliveryManTr.transform.localPosition += _direction * stateMachine.MovementSpeed * deltaTime;

            if (Mathf.Abs(_parkingPoint.x - _deliveryManTr.position.x) < 0.1f)
            {
                _deliveryManTr.position = _parkingPoint;
                stateMachine.SwitchState(new GetDeliveryState(stateMachine));
            }
        }
    }
}