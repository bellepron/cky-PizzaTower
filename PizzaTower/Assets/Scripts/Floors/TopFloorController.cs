using cky.Reuseables.Singleton;
using PizzaTower.Characters.Elevator.StateMachine;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class TopFloorController : SingletonNonPersistent<TopFloorController>
    {
        [field: SerializeField] private ElevatorStateMachine ElevatorSM { get; set; }

        private void Start()
        {
            ElevatorSM.Initialize();
        }
    }
}