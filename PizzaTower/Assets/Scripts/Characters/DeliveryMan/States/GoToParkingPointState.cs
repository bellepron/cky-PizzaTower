using cky.Reuseables.Extension;
using PizzaTower.Characters.DeliveryMan.StateMachine;
using System;
using UnityEngine;

namespace PizzaTower.Characters.DeliveryMan.States
{
    public class GoToParkingPointState : DeliveryManBaseState
    {
        Transform _deliveryManTr;
        Vector3 _parkPoint;
        Vector3 _direction;
        SpriteRenderer _spriteRenderer;

        public GoToParkingPointState(DeliveryManStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _spriteRenderer = stateMachine.GetComponent<SpriteRenderer>();
            _spriteRenderer.flipX = true;

            _deliveryManTr = stateMachine.transform;
            _parkPoint = stateMachine.ParkingPoint;
        }

        public override void Exit()
        {
            _spriteRenderer.flipX = false;
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
            var pizzaCountAtParkSupervisor = stateMachine.ParkSupervisor.PizzaCount;

            if (pizzaCountAtParkSupervisor >= stateMachine.Capacity)
            {
                stateMachine.ParkSupervisor.AddPizza(-stateMachine.Capacity);
                stateMachine.AddPizza(stateMachine.Capacity);
            }
            else
            {
                stateMachine.ParkSupervisor.AddPizza(-pizzaCountAtParkSupervisor);
                stateMachine.AddPizza(pizzaCountAtParkSupervisor);
            }

            stateMachine.SwitchState(new GetDeliveryState(stateMachine));
        }
    }
}