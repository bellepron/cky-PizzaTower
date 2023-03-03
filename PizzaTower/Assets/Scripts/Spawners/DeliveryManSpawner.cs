using cky.Reuseables.Level;
using CKY.Pooling;
using PizzaTower.Characters.DeliveryMan;
using PizzaTower.Characters.DeliveryMan.StateMachine;
using PizzaTower.Floors;
using PizzaTower.Managers;
using System.Linq;
using UnityEngine;

namespace PizzaTower.Spawners
{
    public class DeliveryManSpawner
    {
        private LevelSettings _levelSettings;
        private DeliveryFloorSettings _deliveryFloorSettings;
        private DeliveryManSettings _deliveryManSettings;
        private Transform _prefabTr;
        private Vector3 _spawnPosition;
        private int _deliveryManCount;

        public DeliveryManSpawner()
        {
            _levelSettings = LevelManager.Instance.levelSettings;
            _deliveryFloorSettings = _levelSettings.DeliveryFloorSettings;
            _deliveryManSettings = _levelSettings.DeliveryManSettings;
            _prefabTr = _deliveryFloorSettings.DeliveryManPrefabTr;
            _spawnPosition = _deliveryFloorSettings.SpawnPoint;

            if (_deliveryFloorSettings.DeliveryManAddLevels.Contains(1))
                Spawn();
        }

        private void Spawn()
        {
            if (_deliveryManCount >= _deliveryFloorSettings.DeliveryManAddLevels.Length)
            {
                Debug.LogWarning($"Maximum number of delivery mans reached!");

                return;
            }

            CreateDeliveryMan();

            _deliveryManCount++;
        }

        private void CreateDeliveryMan()
        {
            var deliveryMan = PoolManager.Instance.Spawn(_prefabTr, _spawnPosition, Quaternion.identity);
            var deliveryManTr = deliveryMan.transform;
            var deliveryManSM = deliveryManTr.GetComponent<DeliveryManStateMachine>();
            deliveryManSM.Initialize(_deliveryManSettings, _deliveryFloorSettings, _deliveryManCount);
        }
    }
}