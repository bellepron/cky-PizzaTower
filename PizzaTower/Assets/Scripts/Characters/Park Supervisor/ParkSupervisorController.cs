using cky.Reuseables.Managers;
using cky.Reuseables.Singleton;
using PizzaTower.Interfaces;
using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.Characters.ParkSupervisor
{
    public class ParkSupervisorController : SingletonNonPersistent<ParkSupervisorController>, IPizzaHolder
    {
        private EventManager _eventManager;
        [field: SerializeField] private Transform CollectTransform { get; set; }

        public int PizzaCount { get; set; }

        public Vector3 GetCollectPoint() => CollectTransform.position;

        public Vector3 GetPosition() => transform.position;

        public void RemovePizzas() => PizzaCount = 0;

        private void Start()
        {
            _eventManager = (EventManager)EventManagerAbstract.Instance;

            EventManager.AddPizzaToParkSupervisor += AddPizza;
            EventManager.DeliveryManArrivedToParkSupervisor += DeliveryManArrived;
        }

        private void AddPizza(IPizzaHolder elevator)
        {
            PizzaCount += elevator.PizzaCount;
        }

        private void DeliveryManArrived(IPizzaHolder deliveryMan, int deliveryManCapacity)
        {
            var pizzaCountToAdd = PizzaCount >= deliveryManCapacity ? (deliveryManCapacity) : PizzaCount;
            PizzaCount -= pizzaCountToAdd;
            _eventManager.TriggerAddPizzaToDeliveryMan(deliveryMan, pizzaCountToAdd);
        }
    }
}