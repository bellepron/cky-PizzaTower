using cky.StateMachine.Base;
using PizzaTower.Characters.Chef.States;
using PizzaTower.Floors;
using PizzaTower.FloorSupervisor;
using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.Characters.Chef.StateMachine
{
    public class ChefStateMachine : BaseStateMachine
    {
        [field: SerializeField] public ChefAnimator Animator { get; private set; }
        public FloorController Floor { get; set; }
        public IFloorSupervisor FloorSupervisor { get; set; }
        public float MovementSpeed { get; set; }
        public float CookTime { get; set; }
        public int PizzaCapacity { get; set; }
        public Vector3 TableLocalPosition { get; set; }
        public float ChefDeliveryPointX { get; set; }
        private float InitMovementSpeed { get; set; }
        private float InitCookTime { get; set; }

        public void Initialize(FloorController floor, int orderInFloor, Vector3 tableLocalPosition, IFloorSupervisor floorSupervisor)
        {
            SetVariables(floor, orderInFloor, tableLocalPosition, floorSupervisor);
            ChangeSortingLayer(orderInFloor);
            InitializeAnimator();

            InitState();

            floor.UpgradeEvent += Upgrade;
        }

        private void SetVariables(FloorController floor, int orderInFloor, Vector3 tableLocalPosition, IFloorSupervisor floorSupervisor)
        {
            Floor = floor;

            var levelSettings = LevelManager.Instance.levelSettings;
            var chefSettings = levelSettings.ChefSettings[orderInFloor];
            InitMovementSpeed = MovementSpeed = chefSettings.MovementSpeed;
            InitCookTime = CookTime = chefSettings.CookTime;
            PizzaCapacity = chefSettings.PizzaCapacity;
            TableLocalPosition = tableLocalPosition;
            ChefDeliveryPointX = Floor.FloorSettings.ChefDeliveryPointX;
            FloorSupervisor = floorSupervisor;
        }

        private void ChangeSortingLayer(int orderInFloor)
        {
            GetComponent<SpriteRenderer>().sortingOrder += orderInFloor;
        }

        private void InitializeAnimator()
        {
            Upgrade(1);
        }

        private void InitState()
        {
            SwitchState(new CookState(this));
        }

        private void Upgrade(int floorLevel)
        {
            MovementSpeed = InitMovementSpeed + InitMovementSpeed * (float)(floorLevel - 1) * 0.1f;
            CookTime = InitCookTime - 0.5f * InitCookTime * (1 / (float)Floor.FloorSettings.FloorMaxLevel) * (float)(floorLevel - 1);

            //Debug.Log($"{MovementSpeed} - {CookTime} - {10 / CookTime}");

            Animator?.UpdateValues(MovementSpeed, 10 / CookTime);
        }
    }
}