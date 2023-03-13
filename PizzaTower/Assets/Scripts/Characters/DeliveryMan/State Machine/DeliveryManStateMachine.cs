using cky.Reuseables.Managers;
using cky.StateMachine.Base;
using PizzaTower.Characters.DeliveryMan.States;
using PizzaTower.Interfaces;
using PizzaTower.Floors;
using PizzaTower.Managers;
using UnityEngine;
using PizzaTower.Characters.ParkSupervisor;
using System;
using System.Drawing;

namespace PizzaTower.Characters.DeliveryMan.StateMachine
{
    public class DeliveryManStateMachine : BaseStateMachine, IPizzaHolderWithCapacity
    {
        [field: SerializeField] private DeliveryManAnimator DeliveryManAnimator { get; set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        private DeliveryManSettings DeliveryManSettings { get; set; }
        private DeliveryFloorSettings DeliveryFloorSettings { get; set; }
        public EventManager EventManager { get; set; }
        public ParkSupervisorController ParkSupervisor { get; set; }
        [field: SerializeField] private Transform CollectTransform { get; set; }
        public Vector3 ParkingPoint { get; set; }
        public Vector3 DeliveryPoint { get; set; }
        public float MovementSpeed { get; set; }
        public float GettingDeliveryTime { get; set; }
        public int Capacity { get; set; }
        private float InitMovementSpeed { get; set; }
        private float InitGettingDeliveryTime { get; set; }
        private int InitCapacity { get; set; }
        public int PizzaCount { get; set; }
        private int FloorLevel { get; set; } = 1;
        private float BoostValue { get; set; } = 1;

        public void Initialize(DeliveryManSettings deliveryManSettings, DeliveryFloorSettings deliveryFloorSettings, int order)
        {
            SetVariables(deliveryManSettings, deliveryFloorSettings, order);
            ChangeSortingLayer(order);

            InitState();

            EventManager.DeliveryFloorUpgrade += UpgradeValues;
            EventManager.Boost += Boosted;
        }

        private void Boosted(float boostValue)
        {
            BoostValue = boostValue;
            UpgradeValues(FloorLevel);
        }

        private void SetVariables(DeliveryManSettings deliveryManSettings, DeliveryFloorSettings deliveryFloorSettings, int order)
        {
            DeliveryManSettings = deliveryManSettings;
            DeliveryFloorSettings = deliveryFloorSettings;
            InitMovementSpeed = MovementSpeed = DeliveryManSettings.MovementSpeed;
            InitGettingDeliveryTime = GettingDeliveryTime = DeliveryManSettings.GettingDeliveryTime;
            InitCapacity = Capacity = deliveryManSettings.Capacity;
            ParkingPoint = DeliveryFloorSettings.ParkingPoint;
            DeliveryPoint = DeliveryFloorSettings.DeliveryPoint;
            SpriteRenderer = GetComponent<SpriteRenderer>();
            ParkSupervisor = ParkSupervisorController.Instance;
            EventManager = (EventManager)EventManagerAbstract.Instance;
        }

        private void Upgrade(int deliveryLevel)
        {
            MovementSpeed = InitMovementSpeed + InitMovementSpeed * (float)(deliveryLevel - 1) * 0.1f;
            GettingDeliveryTime = InitGettingDeliveryTime - 0.5f * InitGettingDeliveryTime * (1 / (float)DeliveryFloorSettings.DeliveryMaxLevel) * (float)(deliveryLevel - 1);
            Capacity = InitCapacity * deliveryLevel;

            Debug.Log($"{MovementSpeed} - {GettingDeliveryTime} - {10 / GettingDeliveryTime} - {Capacity}");

            DeliveryManAnimator?.UpdateValues(MovementSpeed);
        }

        void IPizzaHolderWithCapacity.AddPizza(int pizzaCountToAdd) => PizzaCount += pizzaCountToAdd;

        private void ChangeSortingLayer(int order) => SpriteRenderer.sortingOrder += order;

        private void InitState() => SwitchState(new GoToParkingPointState(this));

        public Vector3 GetPosition() => transform.position;

        public Vector3 GetCollectPoint() => CollectTransform.position;

        public void RemovePizzas() => PizzaCount = 0;

        private void UpgradeValues(int floorLevel)
        {
            FloorLevel = floorLevel;

            MovementSpeed = InitMovementSpeed + InitMovementSpeed * (float)(floorLevel - 1) * 0.1f;
            MovementSpeed *= BoostValue;
            Capacity = InitCapacity + floorLevel;
        }
    }
}