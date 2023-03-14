using cky.Reuseables.Managers;
using cky.StateMachine.Base;
using PizzaTower.Characters.Elevator.States;
using PizzaTower.Interfaces;
using PizzaTower.Managers;
using System;
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
        public EventManager EventManager { get; set; }
        public int CurrentFloorIndex { get; set; }
        public float UpSpeed { get; set; }
        public float DownSpeed { get; set; }
        public float DeliveryPointY { get; private set; }
        public int PizzaCount { get; set; }
        private float BoostValue { get; set; } = 1;

        public void Initialize()
        {
            transform.parent = null;

            EventManager.AddFloorSupervisorToElevator += AddFloorSupervisor;
            EventManager.AddPizzaToElevator += AddPizzaFromFloorSupervisor;

            GetVariables();

            InitState();

            EventManager.Boost += Boosted;
        }

        private void Boosted(float boostValue)
        {
            BoostValue = boostValue;

            if (boostValue == 1)
            {
                UpSpeed = ElevatorSettings.UpSpeed;
                DownSpeed = ElevatorSettings.DownSpeed;
            }
            else
            {
                UpSpeed *= BoostValue;
                DownSpeed *= BoostValue;
            }
        }

        private void GetVariables()
        {
            ElevatorSettings = LevelManager.Instance.levelSettings.ElevatorSettings;
            EventManager = (EventManager)EventManagerAbstract.Instance;
            DeliveryPointY = ElevatorSettings.DeliveryPointY;
            UpSpeed = ElevatorSettings.UpSpeed;
            DownSpeed = ElevatorSettings.DownSpeed;
        }

        private void AddFloorSupervisor(IPizzaHolder floorSupervisor)
            => FloorSupervisors.Add(floorSupervisor);

        private void AddPizzaFromFloorSupervisor(IPizzaHolder floorSupervisor)
            => PizzaCount += floorSupervisor.PizzaCount;

        private void InitState() => SwitchState(new GoUpState(this));

        public Vector3 GetPosition() => transform.position;

        public Vector3 GetCollectPoint() => CollectTransform.position;

        public void RemovePizzas() => PizzaCount = 0;
    }
}