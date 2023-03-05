using cky.StateMachine.Base;
using PizzaTower.Characters.Chef.States;
using PizzaTower.Interfaces;
using PizzaTower.Floors;
using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.Characters.Chef.StateMachine
{
    public class ChefStateMachine : BaseStateMachine, IPizzaHolder
    {
        [field: SerializeField] public ChefAnimator Animator { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        [field: SerializeField] private Transform CollectTransform { get; set; }
        public FloorController Floor { get; set; }
        public float MovementSpeed { get; set; }
        public float CookTime { get; set; }
        public int PizzaCapacity { get; set; }
        public Vector3 TableLocalPosition { get; set; }
        public float ChefDeliveryPointX { get; set; }
        private float InitMovementSpeed { get; set; }
        private float InitCookTime { get; set; }
        public int PizzaCount { get; set; }

        public void Initialize(FloorController floor, int orderInFloor, Vector3 tableLocalPosition, IPizzaHolder floorSupervisor)
        {
            SetVariables(floor, orderInFloor, tableLocalPosition, floorSupervisor);
            ChangeSortingLayer(orderInFloor);
            UpgradeValues(1);

            InitState();

            floor.UpgradeEvent += UpgradeValues;
        }

        private void SetVariables(FloorController floor, int orderInFloor, Vector3 tableLocalPosition, IPizzaHolder floorSupervisor)
        {
            Floor = floor;

            var levelSettings = LevelManager.Instance.levelSettings;
            var chefSettings = levelSettings.ChefSettings[orderInFloor];
            InitMovementSpeed = MovementSpeed = chefSettings.MovementSpeed;
            InitCookTime = CookTime = chefSettings.CookTime;
            PizzaCapacity = chefSettings.PizzaCapacity;
            TableLocalPosition = tableLocalPosition;
            ChefDeliveryPointX = Floor.FloorSettings.ChefDeliveryPointX;
        }

        private void ChangeSortingLayer(int orderInFloor)
            => SpriteRenderer.sortingOrder += orderInFloor;

        private void InitState() => SwitchState(new CookState(this));

        public void AddPizza(int value) => PizzaCount += value;

        public void RemovePizzas() => PizzaCount = 0;

        public Vector3 GetPosition() => transform.position;

        public Vector3 GetCollectPoint() => CollectTransform.position;

        private void UpgradeValues(int floorLevel)
        {
            MovementSpeed = InitMovementSpeed + InitMovementSpeed * (float)(floorLevel - 1) * 0.1f;
            CookTime = InitCookTime - 0.5f * InitCookTime * (1 / (float)Floor.FloorSettings.FloorMaxLevel) * (float)(floorLevel - 1);

            Animator?.UpdateValues(MovementSpeed, 10 / CookTime);
        }
    }
}