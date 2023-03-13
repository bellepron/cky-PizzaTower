using CKY.Pooling;
using PizzaTower.Managers;
using UnityEngine;

namespace PizzaTower.Screen
{
    public class BackgroundSpawner : MonoBehaviour
    {
        [SerializeField] BackgroundSettings backGroundSettings;
        Camera _cam;
        float _topY;
        int _counter;

        private void Start()
        {
            _cam = Camera.main;
            _topY = backGroundSettings.StartPosY;

            WhenFloorAdded(0);

            EventManager.AddFloor += WhenFloorAdded;
        }

        private void WhenFloorAdded(int obj)
        {
            var topY = _cam.transform.position.y + _cam.orthographicSize;

            if (topY > _topY)
            {
                _topY = backGroundSettings.StartPosY + _counter * backGroundSettings.IncreaseAmountY;
                var pos = new Vector3(0, _topY, 0);
                PoolManager.Instance.Spawn(backGroundSettings.BackgroundPrefabTr, pos, Quaternion.identity);

                _counter++;

                WhenFloorAdded(0);
            }
        }
    }
}