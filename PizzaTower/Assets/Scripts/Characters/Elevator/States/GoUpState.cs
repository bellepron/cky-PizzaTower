using PizzaTower.Characters.Elevator.StateMachine;
using System.Linq;
using UnityEngine;

namespace PizzaTower.Characters.Elevator.States
{
    public class GoUpState : ElevatorBaseState
    {
        Transform _elevatorTr;
        Vector3 _direction = Vector3.up;

        public GoUpState(ElevatorStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _elevatorTr = stateMachine.transform;
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            if (stateMachine.FloorSupervisors.Count == 0) return;

            var topFloorSupervisor = stateMachine.FloorSupervisors.Last();

            var topY = topFloorSupervisor.PositionY;

            _elevatorTr.position += _direction * stateMachine.ElevatorSettings.UpSpeed * deltaTime;

            if (_elevatorTr.position.y >= topY)
            {
                _elevatorTr.position = new Vector3(_elevatorTr.position.x, topY, 0);

                stateMachine.SwitchState(new CollectState(stateMachine));
            }
        }
    }
}