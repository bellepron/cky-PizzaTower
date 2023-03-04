using cky.Reuseables.Managers;
using PizzaTower.FloorSupervisor;
using System;

namespace PizzaTower.Managers
{
    public class EventManager : EventManagerAbstract
    {
        public static event Action AddFloor;
        public static event Action<IFloorSupervisor> AddFloorToElevator;

        protected override void ResetEvents()
        {
            base.ResetEvents();

            AddFloor = null;
            AddFloorToElevator = null;
        }

        public void AddFloorEvent() => AddFloor?.Invoke();
        public void AddFloorToElevatorEvent(IFloorSupervisor i) => AddFloorToElevator?.Invoke(i);
    }
}