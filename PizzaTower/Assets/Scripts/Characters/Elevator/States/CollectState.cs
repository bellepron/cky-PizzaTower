using PizzaTower.Characters.Elevator.StateMachine;
using UnityEngine;

namespace PizzaTower.Characters.Elevator.States
{
    public class CollectState : ElevatorBaseState
    {
        Transform _elevatorTr;

        public CollectState(ElevatorStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _elevatorTr = stateMachine.transform;

            for (int i = stateMachine.FloorSupervisors.Count - 1; i >= 0; i--)
            {
                if (_elevatorTr.position.y == stateMachine.FloorSupervisors[i].GetPosition().y)
                {
                    stateMachine.CurrentFloorIndex = i;

                    stateMachine.AddPizza(stateMachine.FloorSupervisors[i].PizzaCount);
                    stateMachine.FloorSupervisors[i].RemovePizzas();

                    //if (stateMachine.PizzaCount > 0)
                    //    stateMachine.PizzaModel.SetActive(true);

                    // Animation;

                    if (i > 0)
                    {
                        stateMachine.SwitchState(new GoDownState(stateMachine));
                        break;
                    }
                    else
                    {
                        if (stateMachine.PizzaCount == 0)
                        {
                            stateMachine.SwitchState(new GoUpState(stateMachine));
                            break;
                        }
                        else
                        {
                            stateMachine.SwitchState(new DeliverState(stateMachine));
                            break;
                        }
                    }
                }
            }
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {

        }
    }
}