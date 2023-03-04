using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.FloorSupervisor
{
    public class FloorSupervisorController : MonoBehaviour, IFloorSupervisor
    {
        public float PositionY { get { return transform.position.y; } set { value = transform.position.y; } }
        public int PizzaCount { get; set; }

        public void AddPizza(int value)
        {
            PizzaCount += value;
        }

        public void RemovePizzas()
        {
            PizzaCount = 0;
        }

        private void Start()
        {
            var eventManager = (EventManager)EventManager.Instance;
            eventManager.AddFloorToElevatorEvent(this);
        }
    }
}