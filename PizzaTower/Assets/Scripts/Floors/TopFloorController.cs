using cky.Reuseables.Singleton;
using PizzaTower.Characters.Elevator;
using PizzaTower.Characters.Elevator.StateMachine;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class TopFloorController : SingletonNonPersistent<TopFloorController>
    {
        [SerializeField] private ElevatorStateMachine elevatorSM;
        [SerializeField] private ElevatorPoleController elevatorPole;

        private void Start()
        {
            elevatorSM.Initialize();
        }
    }
}