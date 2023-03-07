using PizzaTower.Managers;
using PizzaTower.Floors;
using CKY.Pooling;
using UnityEngine;
using DG.Tweening;

namespace PizzaTower.Spawners
{
    public class FloorSpawner
    {
        private FloorSettings _floorSettings;
        private Transform _topFloorTr;
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
            _topFloorTr = _floorSettings.TopFloorPrefabTr;
            _floorPrefabTr = _floorSettings.FloorPrefabTr;
            _floorStartPos = _floorSettings.FloorStartPos;
            _increaseQuantityOfFloor = _floorSettings.IncreaseQuantityOfFloor;
            _topFloorOffset = _floorSettings.TopFloorOffset;
        }

        private void CreateTopFloor(Vector3 pos)
        {
            _topFloorTr = PoolManager.Instance.Spawn(_topFloorTr, pos, Quaternion.identity).transform;
        }

        public void AddFloor(int floorCount)
        {
            var pos = _floorStartPos + _increaseQuantityOfFloor * (floorCount - 1);
            var newFloorTr = PoolManager.Instance.Spawn(_floorPrefabTr, pos, Quaternion.identity).transform;

            if (newFloorTr.TryGetComponent<FloorController>(out var floor))
            {
                floor.FloorOrder = floorCount;
            }

            NewFloorAnimation(newFloorTr, pos);
            SetTopFloorPosition(pos + _topFloorOffset);
        }

        private void SetTopFloorPosition(Vector3 pos)
        {
            _topFloorTr.position = pos;

            TopFloorAnimation(pos);
        }

        private void NewFloorAnimation(Transform newFloorTr, Vector3 pos)
        {
            newFloorTr.DOMoveY(pos.y - 0.5f, 0);
            newFloorTr.DOMoveY(pos.y, _floorSettings.FloorOpeningTime);
            newFloorTr.DOScaleY(0, 0);
            newFloorTr.DOScaleY(1, _floorSettings.FloorOpeningTime).SetEase(Ease.InSine);
        }

        private void TopFloorAnimation(Vector3 pos)
        {
            _topFloorTr.DOMoveY(pos.y - _topFloorOffset.y, 0);
            _topFloorTr.DOMoveY(pos.y, _floorSettings.FloorOpeningTime).SetEase(Ease.InSine);
        }
    }
}