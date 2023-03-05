using PizzaTower.Characters.Elevator.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.Elevator.States
{
    public class GoUpState : ElevatorBaseState
    {
        Transform _elevatorTr;
        Vector3 _direction = Vector3.up;
        float _targetY;

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
            if (stateMachine.FloorSupervisors.Count == 0)
                return;

            for (int i = stateMachine.FloorSupervisors.Count - 1; i >= 0; i--)
            {
                var supervisor = stateMachine.FloorSupervisors[i];
                if (supervisor.PizzaCount > 0)
                {
                    _targetY = supervisor.GetPosition().y;
                    break;
                }

                if (i == 0)
                    return;
            }

            _elevatorTr.position += _direction * stateMachine.ElevatorSettings.UpSpeed * deltaTime;

            if (_elevatorTr.position.y >= _targetY)
            {
                _elevatorTr.position = new Vector3(_elevatorTr.position.x, _targetY, 0);

                stateMachine.SwitchState(new CollectState(stateMachine));
            }
        }
    }
}