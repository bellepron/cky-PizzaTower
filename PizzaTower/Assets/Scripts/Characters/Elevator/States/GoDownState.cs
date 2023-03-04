using PizzaTower.Characters.Elevator.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.Elevator.States
{
    public class GoDownState : ElevatorBaseState
    {
        Transform _elevatorTr;
        Vector3 _direction = Vector3.down;
        float _targetFloorY;

        public GoDownState(ElevatorStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _elevatorTr = stateMachine.transform;

            _targetFloorY = stateMachine.FloorSupervisors[stateMachine.CurrentFloorIndex - 1].PositionY;
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            _elevatorTr.position += _direction * stateMachine.UpSpeed * deltaTime;

            if (_elevatorTr.position.y <= _targetFloorY)
            {
                _elevatorTr.position = new Vector3(_elevatorTr.position.x, _targetFloorY, 0);

                stateMachine.SwitchState(new CollectState(stateMachine));
            }
        }
    }
}