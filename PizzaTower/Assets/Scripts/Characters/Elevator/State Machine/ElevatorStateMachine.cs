using cky.StateMachine.Base;
using PizzaTower.Characters.Elevator.States;
using PizzaTower.Interfaces;
using PizzaTower.Characters.ParkSupervisor;
using PizzaTower.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTower.Characters.Elevator.StateMachine
{
    public class ElevatorStateMachine : BaseStateMachine, IPizzaHolder
    {
        public ElevatorSettings ElevatorSettings { get; set; }
        [field: SerializeField] public GameObject PizzaModel { get; }
        [field: SerializeField] private Transform CollectTransform { get; set; }
        public List<IPizzaHolder> FloorSupervisors { get; set; } = new List<IPizzaHolder>();
        public IPizzaHolder ParkSupervisor { get; set; }
        public int CurrentFloorIndex { get; set; }
        public float UpSpeed { get; set; }
        public float DownSpeed { get; set; }
        public float DeliveryPointY { get; private set; }
        public int PizzaCount { get; set; }

        public void Initialize()
        {
            transform.parent = null;
            //PizzaModel.SetActive(false);

            EventManager.AddFloorToElevatorEvent += AddFloor;

            GetVariables();

            InitState();
        }

        private void GetVariables()
        {
            ElevatorSettings = LevelManager.Instance.levelSettings.ElevatorSettings;
            ParkSupervisor = ParkSupervisorController.Instance.GetComponent<IPizzaHolder>();
            DeliveryPointY = ElevatorSettings.DeliveryPointY;
        }

        private void AddFloor(IPizzaHolder floorSupervisor)
        {
            FloorSupervisors.Add(floorSupervisor);
        }

        private void InitState()
        {
            SwitchState(new GoUpState(this));
        }

        public Vector3 GetPosition() => transform.position;

        public Vector3 GetCollectPoint() => CollectTransform.position;

        public void AddPizza(int value) => PizzaCount += value;

        public void RemovePizzas() => PizzaCount = 0;
    }
}