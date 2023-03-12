using PizzaTower.Managers;
using PizzaTower.Floors;
using CKY.Pooling;
using UnityEngine;
using PizzaTower.Helpers;

namespace PizzaTower.Spawners
{
    public class FloorSpawner
    {
        private FloorSettings _floorSettings;
        private Transform _topFloorPrefabTr;
        private TopFloorController _topFloorController;
        private Transform _floorPrefabTr;

        private Vector3 _floorStartPos;
        private Vector3 _increaseQuantityOfFloor;
        private Vector3 _topFloorOffset;

        public FloorSpawner()
        {
            GetVariables();
            CreateTopFloor(_floorStartPos);

            EventManager.AddFloor += AddFloor;
        }

        private void GetVariables()
        {
            _floorSettings = LevelManager.Instance.levelSettings.FloorSettings;
            _topFloorPrefabTr = _floorSettings.TopFloorPrefabTr;
            _floorPrefabTr = _floorSettings.FloorPrefabTr;
            _floorStartPos = _floorSettings.FloorStartPos;
            _increaseQuantityOfFloor = _floorSettings.IncreaseQuantityOfFloor;
            _topFloorOffset = _floorSettings.TopFloorOffset;
        }

        private void CreateTopFloor(Vector3 pos)
        {
            _topFloorController = PoolManager.Instance.Spawn(_topFloorPrefabTr, pos, Quaternion.identity).GetComponent<TopFloorController>();
        }

        public void AddFloor(int floorCount)
        {
            var pos = _floorStartPos + _increaseQuantityOfFloor * (floorCount - 1);
            var newFloorTr = PoolManager.Instance.Spawn(_floorPrefabTr, pos, Quaternion.identity).transform;

            if (newFloorTr.TryGetComponent<FloorController>(out var floor))
            {
                floor.FloorOrder = floorCount;
            }

            newFloorTr.NewFloorAnimation(pos, _floorSettings.FloorOpeningTime);
            SetTopFloorPosition(pos + _topFloorOffset);
        }

        private void SetTopFloorPosition(Vector3 pos)
        {
            _topFloorController.SetPosition(pos, _topFloorOffset, _floorSettings);
        }
    }
}