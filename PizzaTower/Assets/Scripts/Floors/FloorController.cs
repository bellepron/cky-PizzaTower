using PizzaTower.Characters.FloorSupervisor;
using PizzaTower.Managers;
using PizzaTower.Spawners;
using System;
using UnityEngine;

namespace PizzaTower.Floors
{
    public class FloorController : MonoBehaviour
    {
        public event Action<int> UpgradeEvent;

        public FloorSettings FloorSettings { get; private set; }
        [field: SerializeField] public FloorCanvasController FloorCanvasController { get; private set; }
        [field: SerializeField] public FloorSupervisorController FloorSupervisor { get; private set; }
        public int FloorOrder { get; set; }
        public ChefSpawner ChefSpawner { get; set; }

        private int _floorLevel = 1;

        private void Start()
        {
            FloorSettings = LevelManager.Instance.levelSettings.FloorSettings;
            FloorCanvasController.Initialize(this);
            ChefSpawner = new ChefSpawner(this, FloorSupervisor);
        }

        public void UpgradeFloor()
        {
            _floorLevel++;
            UpgradeEvent?.Invoke(_floorLevel);
        }
    }
}