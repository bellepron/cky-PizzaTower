using cky.StateMachine.Base;
using PizzaTower.Characters.Elevator.States;
using PizzaTower.FloorSupervisor;
using PizzaTower.Managers;
using System.Collections.Generic;

namespace PizzaTower.Characters.Elevator.StateMachine
{
    public class ElevatorStateMachine : BaseStateMachine
    {
        public List<IFloorSupervisor> FloorSupervisors { get; set; } = new List<IFloorSupervisor>();
        public int CollectedPizzaCount { get; set; }
        public int CurrentFloorIndex { get; set; }
        public float UpSpeed { get; set; } = 3;
        public float DownSpeed { get; set; } = 3;

        public void Initialize()
        {
            transform.parent = null;

            EventManager.AddFloorToElevator += AddFloor;

            SwitchState(new GoUpState(this));
        }

        private void AddFloor(IFloorSupervisor floorSupervisor)
        {
            FloorSupervisors.Add(floorSupervisor);
        }
    }
}