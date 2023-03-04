using cky.StateMachine.Base;
using PizzaTower.Characters.Elevator.States;
using PizzaTower.FloorSupervisor;
using PizzaTower.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTower.Characters.Elevator.StateMachine
{
    public class ElevatorStateMachine : BaseStateMachine
    {
        public ElevatorSettings ElevatorSettings { get; set; }
        [field: SerializeField] public GameObject PizzaModel { get; private set; }
        public List<IFloorSupervisor> FloorSupervisors { get; set; } = new List<IFloorSupervisor>();
        public int CollectedPizzaCount { get; set; }
        public int CurrentFloorIndex { get; set; }
        public float UpSpeed { get; set; }
        public float DownSpeed { get; set; }
        public float DeliveryPointY { get; private set; }

        public void Initialize()
        {
            transform.parent = null;
            PizzaModel.SetActive(false);

            EventManager.AddFloorToElevator += AddFloor;

            GetVariables();

            InitState();
        }

        private void GetVariables()
        {
            ElevatorSettings = LevelManager.Instance.levelSettings.ElevatorSettings;
            DeliveryPointY = ElevatorSettings.DeliveryPointY;
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