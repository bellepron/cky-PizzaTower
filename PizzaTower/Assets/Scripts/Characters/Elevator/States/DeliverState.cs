using PizzaTower.Characters.Elevator.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.Elevator.States
{
    public class DeliverState : ElevatorBaseState
    {
        Transform _elevatorTr;
        float _deliveryPointY;
        Vector3 _direction = Vector3.down;

        public DeliverState(ElevatorStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _elevatorTr = stateMachine.transform;
            _deliveryPointY = stateMachine.DeliveryPointY;
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            _elevatorTr.position += _direction * stateMachine.ElevatorSettings.DownSpeed * deltaTime;

            if (_elevatorTr.position.y <= _deliveryPointY)
            {
                _elevatorTr.position = new Vector3(_elevatorTr.position.x, _deliveryPointY, 0);

                ArrivedToTheDeliveryPoint();
            }
        }

        private void ArrivedToTheDeliveryPoint()
        {
            // TODO: Give Pizzas to ParkingSupervisor
            stateMachine.CollectedPizzaCount = 0;
            stateMachine.PizzaModel.SetActive(false);

            stateMachine.SwitchState(new GoUpState(stateMachine));
        }
    }
}