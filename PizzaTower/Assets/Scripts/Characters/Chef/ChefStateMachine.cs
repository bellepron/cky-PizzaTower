using cky.StateMachine.Base;
using PizzaTower.Characters.Chef.States;
using PizzaTower.Floor;
using UnityEngine;

namespace PizzaTower.Characters.Chef
{
    public class ChefStateMachine : BaseStateMachine
    {
        [field: SerializeField] public ChefAnimator Animator { get; private set; }
        public FloorController Floor { get; set; }
        public float MovementSpeed { get; set; }
        public float CookTime { get; set; }
        public Vector3 TableLocalPosition { get; set; }
        public float ChefDeliveryPointX { get; set; }
        private float InitMovementSpeed { get; set; }
        private float InitCookTime { get; set; }

        public void Initialize(FloorController floor, FloorSettings floorSettings, int orderInFloor, Vector3 tableLocalPosition)
        {
            SetVariables(floor, floorSettings, orderInFloor, tableLocalPosition);
            ChangeSortingLayer(orderInFloor);
            InitializeAnimator();

            InitState();

            floor.UpgradeEvent += Upgrade;
        }

        private void SetVariables(FloorController floor, FloorSettings floorSettings, int orderInFloor, Vector3 tableLocalPosition)
        {
            Floor = floor;

            var chefSettings = floorSettings.ChefSettings[orderInFloor];
            InitMovementSpeed = MovementSpeed = chefSettings.MovementSpeed;
            InitCookTime = CookTime = chefSettings.CookTime;
            TableLocalPosition = tableLocalPosition;
            ChefDeliveryPointX = floorSettings.ChefDeliveryPointX;
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