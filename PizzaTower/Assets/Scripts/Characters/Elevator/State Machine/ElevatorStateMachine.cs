using cky.StateMachine.Base;
using PizzaTower.Characters.Elevator.States;
using PizzaTower.FloorSupervisor;
using PizzaTower.Managers;
using System;
using System.Collections.Generic;

namespace PizzaTower.Characters.Elevator.StateMachine
{
    public class ElevatorStateMachine : BaseStateMachine
    {
        public List<IFloorSupervisor> FloorSupervisors { get; set; } = new List<IFloorSupervisor>();
        public int CollectedPizzaCount { get; set; }
        public int CurrentFloorIndex { get; set; }
        public float UpSpeed { get; set; }
        public float DownSpeed { get; set; }

        public void Initialize()
        {
            transform.parent = null;

            EventManager.AddFloorToElevator += AddFloor;

            GetVariables();

            InitState();
        }

        private void GetVariables()
        {
            var elevatorSettings = LevelManager.Instance.levelSettings.ElevatorSettings;
            UpSpeed = elevatorSettings.UpSpeed;
            DownSpeed = elevatorSettings.DownSpeed;
        }

        private void AddFloor(IFloorSupervisor floorSupervisor)
        {
            FloorSupervisors.Add(floorSupervisor);
        }

        private void InitState()
        {
            SwitchState(new GoUpState(this));
        }
    }
}