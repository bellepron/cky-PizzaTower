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
        public static event Action<IPizzaHolder, int> DeliveryManArrivedToParkSupervisor;
        public static event Action<IPizzaHolder, int> AddPizzaToDeliveryMan;
        public static event Action<string> AddCoin;

        protected override void ResetEvents()
        {
            base.ResetEvents();

            AddFloor = null;
            DeliveryFloorUpgrade = null;
            AddFloorSupervisorToElevator = null;
            AddPizzaToElevator = null;
            AddPizzaToParkSupervisor = null;
            AddPizzaToDeliveryMan = null;
            AddCoin = null;
        }

        public void TriggerAddFloor(int order) => AddFloor?.Invoke(order);
        public void TriggerDeliveryFloorUpgrade(int deliveryFloorLevel) => DeliveryFloorUpgrade?.Invoke(deliveryFloorLevel);
        public void TriggerAddFloorSupervisorToElevator(IPizzaHolder i) => AddFloorSupervisorToElevator?.Invoke(i);
        public void TriggerAddPizzaToElevator(IPizzaHolder i) => AddPizzaToElevator?.Invoke(i);
        public void TriggerAddPizzaToParkSupervisor(IPizzaHolder i) => AddPizzaToParkSupervisor?.Invoke(i);
        public void TriggerDeliveryManArrivedToParkSupervisor(IPizzaHolder i, int capacity) => DeliveryManArrivedToParkSupervisor?.Invoke(i, capacity);
        public void TriggerAddPizzaToDeliveryMan(IPizzaHolder i, int pizzaCountToAdd) => AddPizzaToDeliveryMan?.Invoke(i, pizzaCountToAdd);
        public void TriggerAddCoin(string value) => AddCoin?.Invoke(value);
    }
}