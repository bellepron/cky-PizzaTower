using cky.Reuseables.Singleton;
using PizzaTower.Characters.Elevator.StateMachine;
using PizzaTower.Helpers;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class TopFloorController : SingletonNonPersistent<TopFloorController>
    {
        [field: SerializeField] private ElevatorStateMachine ElevatorSM { get; set; }
        private float _targetHeight;


        private void Start()
        {
            ElevatorSM.Initialize();
        }

        public float GetTargetHeight() => _targetHeight;

        public void SetPosition(Vector3 pos, Vector3 topFloorOffset, FloorSettings floorSettings)
        {
            _targetHeight = pos.y;
            transform.TopFloorAnimation(pos, topFloorOffset.y, floorSettings.FloorOpeningTime);
        }
    }
}