using cky.Reuseables.Managers;
using PizzaTower.Interfaces;
using System;

namespace PizzaTower.Managers
{
    public class EventManager : EventManagerAbstract
    {
        public static event Action AddFloorEvent;
        public static event Action<IPizzaHolder> AddFloorToElevatorEvent;
        public static event Action<int> UpdateCoinEvent;

        protected override void ResetEvents()
        {
            base.ResetEvents();

            AddFloorEvent = null;
            AddFloorToElevatorEvent = null;
            UpdateCoinEvent = null;
        }

        public void TriggerAddFloorEvent() => AddFloorEvent?.Invoke();
        public void TriggerAddFloorToElevatorEvent(IPizzaHolder i) => AddFloorToElevatorEvent?.Invoke(i);
        public void TriggerUpdateCoinEvent(int value) => UpdateCoinEvent?.Invoke(value);
    }
}