using cky.Reuseables.Managers;
using PizzaTower.Interfaces;
using System;

namespace PizzaTower.Managers
{
    public class EventManager : EventManagerAbstract
    {
        public static event Action AddFloorEvent;
        public static event Action<IPizzaHolder> AddFloorToElevatorEvent;
        public static event Action<int> UpdateMoneyEvent;

        protected override void ResetEvents()
        {
            base.ResetEvents();

            AddFloorEvent = null;
            AddFloorToElevatorEvent = null;
            UpdateMoneyEvent = null;
        }

        public void TriggerAddFloorEvent() => AddFloorEvent?.Invoke();
        public void TriggerAddFloorToElevatorEvent(IPizzaHolder i) => AddFloorToElevatorEvent?.Invoke(i);
        public void TriggerUpdateMoneyEvent(int value) => UpdateMoneyEvent?.Invoke(value);
    }
}