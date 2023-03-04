using cky.Reuseables.Managers;
using System;

namespace PizzaTower.Managers
{
    public class EventManager : EventManagerAbstract
    {
        public static event Action AddFloor;

        protected override void ResetEvents()
        {
            base.ResetEvents();

            AddFloor = null;
        }

        public void AddFloorEvent() => AddFloor?.Invoke();
    }
}