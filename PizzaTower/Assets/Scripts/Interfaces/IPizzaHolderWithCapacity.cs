using UnityEngine;

namespace PizzaTower.Interfaces
{
    public interface IPizzaHolderWithCapacity : IPizzaHolder
    {
        public int Capacity { get; set; }
        void AddPizza(int pizzaCountToAdd);
    }
}