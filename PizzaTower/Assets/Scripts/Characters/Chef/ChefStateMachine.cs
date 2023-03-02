using cky.StateMachine.Base;
using PizzaTower.Characters.Chef.States;
using PizzaTower.Floors;
using UnityEngine;

namespace PizzaTower.Characters.Chef
{
    public class ChefStateMachine : BaseStateMachine
    {
        [field: SerializeField] public ChefAnimator Animator { get; private set; }
        public Floor Floor { get; set; }
        public float MovementSpeed { get; set; }
        public float CookTime { get; set; }
        public Vector3 TableLocalPosition { get; set; }
        public float ChefDeliveryPointX { get; set; }

        public void Initialize(Floor floor, FloorSettings floorSettings, int orderInFloor, Vector3 tableLocalPosition)
        {
            SetVariables(floor, floorSettings, orderInFloor, tableLocalPosition);
            ChangeSortingLayer(orderInFloor);
            InitializeAnimator();

            InitState();
        }

        private void SetVariables(Floor floor, FloorSettings floorSettings, int orderInFloor, Vector3 tableLocalPosition)
        {
            Floor = floor;

            var chefSettings = floorSettings.ChefSettings[orderInFloor];
            MovementSpeed = chefSettings.MovementSpeed;
            CookTime = chefSettings.CookTime;
            TableLocalPosition = tableLocalPosition;
            ChefDeliveryPointX = floorSettings.ChefDeliveryPointX;
        }

        private void ChangeSortingLayer(int orderInFloor)
        {
            GetComponent<SpriteRenderer>().sortingOrder += orderInFloor;
        }

        private void InitializeAnimator()
        {
            Animator?.Initialize(Floor, MovementSpeed, CookTime);
        }

        private void InitState()
        {
            SwitchState(new CookState(this));
        }
    }
}