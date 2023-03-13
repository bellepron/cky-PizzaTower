using cky.Reuseables.Managers;
using PizzaTower.Interfaces;
using System;

namespace PizzaTower.Managers
{
    public class EventManager : EventManagerAbstract
    {
        public static event Action<int> AddFloor;
        public static event Action<int> DeliveryFloorUpgrade;
        public static event Action<IPizzaHolder> AddFloorSupervisorToElevator;
        public static event Action<IPizzaHolder> AddPizzaToElevator;
        public static event Action<IPizzaHolder> AddPizzaToParkSupervisor;
        public static event Action<IPizzaHolderWithCapacity> DeliveryManArrivedToParkSupervisor;
        public static event Action<string> AddCoin, RemoveCoin;
        public static event Action UpdateActivationOfUpgradeButtons;
        public static event Action<float> Boost;

        protected override void ResetEvents()
        {
            base.ResetEvents();

            AddFloor = null;
            DeliveryFloorUpgrade = null;
            AddFloorSupervisorToElevator = null;
            AddPizzaToElevator = null;
            AddPizzaToParkSupervisor = null;
            DeliveryManArrivedToParkSupervisor = null;
            AddCoin = null;
            RemoveCoin = null;
            UpdateActivationOfUpgradeButtons = null;
            Boost = null;
        }

        public void TriggerAddFloor(int order)
            => AddFloor?.Invoke(order);

        public void TriggerDeliveryFloorUpgrade(int deliveryFloorLevel)
            => DeliveryFloorUpgrade?.Invoke(deliveryFloorLevel);

        public void TriggerAddFloorSupervisorToElevator(IPizzaHolder i)
            => AddFloorSupervisorToElevator?.Invoke(i);

        public void TriggerAddPizzaToElevator(IPizzaHolder i)
            => AddPizzaToElevator?.Invoke(i);

        public void TriggerAddPizzaToParkSupervisor(IPizzaHolder i)
            => AddPizzaToParkSupervisor?.Invoke(i);

        public void TriggerDeliveryManArrivedToParkSupervisor(IPizzaHolderWithCapacity i)
            => DeliveryManArrivedToParkSupervisor?.Invoke(i);

        public void TriggerAddCoin(string value)
            => AddCoin?.Invoke(value);

        public void TriggerRemoveCoin(string value)
            => RemoveCoin?.Invoke(value);

        public void TriggerUpdateActivationOfUpgradeButtons()
            => UpdateActivationOfUpgradeButtons?.Invoke();

        public void TriggerBoost(float value = 1)
            => Boost?.Invoke(value);
    }
}