using cky.Reuseables.Level;
using cky.StateMachine.Base;
using PizzaTower.Characters.DeliveryMan.States;
using PizzaTower.Floors;
using UnityEngine;

namespace PizzaTower.Characters.DeliveryMan.StateMachine
{
    public class DeliveryManStateMachine : BaseStateMachine
    {
        [field: SerializeField] private DeliveryManAnimator DeliveryManAnimator { get; set; }
        private DeliveryManSettings DeliveryManSettings { get; set; }
        private DeliveryFloorSettings DeliveryFloorSettings { get; set; }
        public Vector3 ParkingPoint { get; set; }
        public Vector3 DeliveryPoint { get; set; }
        public float MovementSpeed { get; set; }
        public float GettingDeliveryTime { get; set; }
        public int Capacity { get; set; }
        private float InitMovementSpeed { get; set; }
        private float InitGettingDeliveryTime { get; set; }
        private int InitCapacity { get; set; }

        public void Initialize(DeliveryManSettings deliveryManSettings, DeliveryFloorSettings deliveryFloorSettings, int order)
        {
            SetVariables(deliveryManSettings, deliveryFloorSettings, order);
            ChangeSortingLayer(order);

            InitState();

            //floor.UpgradeEvent += Upgrade;
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
        }

        private void ChangeSortingLayer(int order)
        {
            GetComponent<SpriteRenderer>().sortingOrder += order;
        }

        private void InitState()
        {
            SwitchState(new GoToParkingPointState(this));
        }

        private void Upgrade(int deliveryLevel)
        {
            MovementSpeed = InitMovementSpeed + InitMovementSpeed * (float)(deliveryLevel - 1) * 0.1f;
            GettingDeliveryTime = InitGettingDeliveryTime - 0.5f * InitGettingDeliveryTime * (1 / (float)DeliveryFloorSettings.DeliveryMaxLevel) * (float)(deliveryLevel - 1);
            Capacity = InitCapacity * deliveryLevel;

            Debug.Log($"{MovementSpeed} - {GettingDeliveryTime} - {10 / GettingDeliveryTime} - {Capacity}");

            DeliveryManAnimator?.UpdateValues(MovementSpeed);
        }
    }
}