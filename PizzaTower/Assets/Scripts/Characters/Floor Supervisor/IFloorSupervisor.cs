using UnityEngine;

namespace PizzaTower.FloorSupervisor
{
    public interface IFloorSupervisor
    {
        public float PositionY { get; set; }
        public int PizzaCount { get; set; }
        void AddPizza(int value);
        void RemovePizzas();
    }
}