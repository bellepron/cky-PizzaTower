using CKY.Pooling;
using PizzaTower.Characters.Chef;
using PizzaTower.Managers;
using System.Linq;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class ChefSpawner
    {
        public Floor floor;
        public Transform floorTransform;
        private FloorSettings _floorSettings;
        private Vector3[] _chefSpawnLocalPositions;
        private Transform _chefPrefabTr;
        private Transform _chefsTablePrefabTr;
        private int _chefCount;

        public ChefSpawner(Floor floor)
        {
            this.floor = floor;
            floorTransform = floor.transform;
            _floorSettings = LevelManager.Instance.levelSettings.FloorSettings;
            _chefSpawnLocalPositions = _floorSettings.ChefSpawnLocalPositions;
            _chefPrefabTr = _floorSettings.ChefPrefabTr;
            _chefsTablePrefabTr = _floorSettings.ChefsTablePrefabTr;

            floor.UpgradeEvent += Upgrade;

            if (_floorSettings.ChefAddLevels.Contains(0))
                Spawn();
        }

        private void Upgrade(int floorLevel)
        {
            if (_floorSettings.ChefAddLevels.Contains(floorLevel))
                Spawn();
        }

        public void Spawn()
        {
            if (_chefCount >= _chefSpawnLocalPositions.Length)
            {
                Debug.LogWarning($"Maximum number of chefs reached!");

                return;
            }

            var spawnPos = _chefSpawnLocalPositions[_chefCount];
            CreateChef(spawnPos);
            CreateChefsTable(spawnPos);

            _chefCount++;
        }

        private void CreateChef(Vector3 spawnPos)
        {
            var chefTr = PoolManager.Instance.Spawn(_chefPrefabTr, spawnPos, Quaternion.identity).transform;
            chefTr.parent = floorTransform;
            chefTr.localPosition = spawnPos;
            var chefSM = chefTr.GetComponent<ChefStateMachine>();
            chefSM.Initialize(floor, _floorSettings, _chefCount, spawnPos);
        }

        private void CreateChefsTable(Vector3 spawnPos)
        {
            var chefsTableTr = PoolManager.Instance.Spawn(_chefsTablePrefabTr, spawnPos, Quaternion.identity).transform;
            chefsTableTr.parent = this.floorTransform;
            chefsTableTr.localPosition = spawnPos;
        }
    }
}