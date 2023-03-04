using CKY.Pooling;
using PizzaTower.Characters.Chef;
using PizzaTower.Characters.Chef.StateMachine;
using PizzaTower.Floors;
using PizzaTower.FloorSupervisor;
using PizzaTower.Managers;
using System.Linq;
using UnityEngine;

namespace PizzaTower.Spawners
{
    public class ChefSpawner
    {
        private FloorController _floor;
        private IFloorSupervisor _floorSupervisor;
        private Transform _floorTransform;
        private FloorSettings _floorSettings;
        private Vector3[] _chefSpawnLocalPositions;
        private ChefSettings[] _chefSettings;
        private int _chefCount;

        public ChefSpawner(FloorController floor, FloorSupervisorController floorSupervisor)
        {
            _floor = floor;
            _floorSupervisor = floorSupervisor.GetComponent<IFloorSupervisor>();
            _floorTransform = floor.transform;
            _floorSettings = floor.FloorSettings;
            _chefSpawnLocalPositions = _floorSettings.ChefSpawnLocalPositions;

            _chefSettings = LevelManager.Instance.levelSettings.ChefSettings;

            floor.UpgradeEvent += Upgrade;

            if (_floorSettings.ChefAddLevels.Contains(1))
                Spawn();
        }

        private void Upgrade(int floorLevel)
        {
            if (_floorSettings.ChefAddLevels.Contains(floorLevel))
                Spawn();
        }

        public void Spawn()
        {
            CreateChef();
            CreateChefsTable();

            _chefCount++;
        }

        private void CreateChef()
        {
            var pos = _chefSpawnLocalPositions[_chefCount];
            var chefTr = PoolManager.Instance.Spawn(_chefSettings[_chefCount].ChefPrefabTr, pos, Quaternion.identity).transform;
            chefTr.parent = _floorTransform;
            chefTr.localPosition = pos;
            var chefSM = chefTr.GetComponent<ChefStateMachine>();
            chefSM.Initialize(_floor, _chefCount, pos, _floorSupervisor);
        }

        private void CreateChefsTable()
        {
            var pos = _chefSpawnLocalPositions[_chefCount];
            var chefsTableTr = PoolManager.Instance.Spawn(_chefSettings[_chefCount].ChefsTablePrefabTr, pos, Quaternion.identity).transform;
            chefsTableTr.parent = this._floorTransform;
            chefsTableTr.localPosition = pos;
        }
    }
}