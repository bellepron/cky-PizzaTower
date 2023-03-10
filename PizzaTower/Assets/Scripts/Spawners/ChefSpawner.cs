using CKY.Pooling;
using PizzaTower.Characters.Chef;
using PizzaTower.Characters.Chef.StateMachine;
using PizzaTower.Characters.FloorSupervisor;
using PizzaTower.Interfaces;
using PizzaTower.Floors;
using PizzaTower.Managers;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using PizzaTower.Helpers;

namespace PizzaTower.Spawners
{
    public class ChefSpawner
    {
        private FloorController _floor;
        private IPizzaHolder _floorSupervisor;
        private Transform _floorTransform;
        private FloorSettings _floorSettings;
        private Vector3[] _chefSpawnLocalPositions;
        private ChefSettings[] _chefSettings;
        private int _chefCount;

        public ChefSpawner(FloorController floor, FloorSupervisorController floorSupervisor)
        {
            _floor = floor;
            _floorSupervisor = floorSupervisor.GetComponent<IPizzaHolder>();
            _floorTransform = floor.transform;
            _floorSettings = floor.FloorSettings;
            _chefSpawnLocalPositions = _floorSettings.ChefSpawnLocalPositions;

            _chefSettings = LevelManager.Instance.levelSettings.ChefSettings;

            floor.UpgradeEvent += Upgrade;

            if (_floorSettings.ChefAddLevels.Contains(1))
                DOVirtual.DelayedCall(_floorSettings.FloorOpeningTime, () => Spawn());
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
            var chefIndex = _chefCount;
            var pos = _chefSpawnLocalPositions[chefIndex];
            Transform chefTr = null;

            DOVirtual.DelayedCall(_floorSettings.ChefsTableOpeningTime, () =>
            {
                chefTr = PoolManager.Instance.Spawn(_chefSettings[chefIndex].ChefPrefabTr, pos, Quaternion.identity).transform;
                chefTr.parent = _floorTransform;
                chefTr.localPosition = pos;

                chefTr.StaffOpeningAnimation(chefTr.localScale, _floorSettings.ChefOpeningTime).OnComplete(() =>
                       {
                           if (chefTr.TryGetComponent<ChefStateMachine>(out var chefSM))
                           {
                               chefSM.Initialize(_floor, chefIndex, pos, _floorSupervisor);
                           }
                       });
            });
        }

        private void CreateChefsTable()
        {
            var pos = _chefSpawnLocalPositions[_chefCount];
            var chefsTableTr = PoolManager.Instance.Spawn(_chefSettings[_chefCount].ChefsTablePrefabTr, pos, Quaternion.identity).transform;
            chefsTableTr.parent = this._floorTransform;
            chefsTableTr.localPosition = pos;

            chefsTableTr.TableOpeningAnimation(chefsTableTr.localScale, _floorSettings.ChefsTableOpeningTime);
        }
    }
}