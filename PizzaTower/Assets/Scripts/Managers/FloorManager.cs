using CKY.Pooling;
using UnityEngine;

namespace PizzaTower.Managers
{
    public class FloorManager : MonoBehaviour
    {
        [SerializeField] Transform topFloorTr;
        [SerializeField] Transform floorPrefabTr;
        Vector3 _floorStartPos = new Vector3(0, -10, 0);
        Vector3 _increaseQuantityOfFloor = new Vector3(0, 4.2f, 0);
        Vector3 _topFloorOffset = new Vector3(0, 3.1f, 0);
        int _floorCount;

        private void Start()
        {
            SetTopFloorPosition(_floorStartPos);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddFloor();
            }
        }

        public void AddFloor()
        {
            var pos = _floorStartPos + _increaseQuantityOfFloor * _floorCount;
            var newFloor = PoolManager.Instance.Spawn(floorPrefabTr, pos, Quaternion.identity);

            _floorCount++;

            SetTopFloorPosition(pos + _topFloorOffset);
        }

        private void SetTopFloorPosition(Vector3 pos)
        {
            topFloorTr.position = pos;
        }
    }
}