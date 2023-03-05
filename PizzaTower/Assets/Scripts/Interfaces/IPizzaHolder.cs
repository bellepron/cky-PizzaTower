using UnityEngine;

namespace PizzaTower.Interfaces
{
    public interface IPizzaHolder
    {
        public int PizzaCount { get; set; }
        Vector3 GetPosition();
        Vector3 GetCollectPoint();
        void RemovePizzas();
    }
}