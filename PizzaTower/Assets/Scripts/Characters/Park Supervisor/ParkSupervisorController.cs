using cky.Reuseables.Singleton;
using PizzaTower.Interfaces;
using UnityEngine;

namespace PizzaTower.Characters.ParkSupervisor
{
    public class ParkSupervisorController : SingletonNonPersistent<ParkSupervisorController>, IPizzaHolder
    {
        [field: SerializeField] private Transform CollectTransform { get; set; }

        public int PizzaCount { get; set; }

        public void AddPizza(int value) => PizzaCount += value;

        public Vector3 GetCollectPoint() => CollectTransform.position;

        public Vector3 GetPosition() => transform.position;

        public void RemovePizzas() => PizzaCount = 0;
    }
}