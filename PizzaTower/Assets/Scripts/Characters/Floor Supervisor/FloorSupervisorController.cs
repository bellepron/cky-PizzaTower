using PizzaTower.Interfaces;
using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.Characters.FloorSupervisor
{
    public class FloorSupervisorController : MonoBehaviour, IPizzaHolder
    {
        [field: SerializeField] private Transform CollectTransform { get; set; }

        public int PizzaCount { get; set; }

        public Vector3 GetPosition() => transform.position;

        public Vector3 GetCollectPoint() => CollectTransform.position;

        public void AddPizza(int value) => PizzaCount += value;

        public void RemovePizzas() => PizzaCount = 0;

        private void Start()
        {
            var eventManager = (EventManager)EventManager.Instance;
            eventManager.TriggerAddFloorToElevatorEvent(this);
        }
    }
}